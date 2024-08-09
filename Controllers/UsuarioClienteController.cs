using DecoArtp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecoArtp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioClienteController : ControllerBase
    {
        private readonly DeskArtContext _baseDatos;

        public UsuarioClienteController(DeskArtContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // Método para obtener la lista de todos los productos
        [HttpGet]
        [Route("ListaUsuariosCliente")]
        public async Task<IActionResult> Lista()
        {
            var listaUsuarios = await _baseDatos.Usuarios.ToListAsync();
            return Ok(listaUsuarios);
        }
        [HttpPost]
        [Route("AgregarUsuarioCliente")]
        public async Task<IActionResult> AgregarUsuarioCliente([FromBody] Usuario nuevoUsuarioCliente)
        {
            if (nuevoUsuarioCliente == null)
            {
                return BadRequest("Datos de usuario inválidos.");
            }

            // Validaciones adicionales si es necesario

            await _baseDatos.Usuarios.AddAsync(nuevoUsuarioCliente);
            await _baseDatos.SaveChangesAsync();

            return Ok(nuevoUsuarioCliente);
        }
        [HttpPut]
        [Route("EditarUsuarioCliente/{idUsuario}")]
        public async Task<IActionResult> EditarUsuario(int idUsuario, [FromBody] Usuario usuarioActualizado)
        {
            if (usuarioActualizado == null || idUsuario != usuarioActualizado.IdUsuario)
            {
                return BadRequest("Datos de usuario inválidos o ID no coincide.");
            }

            var usuarioExistente = await _baseDatos.Usuarios.FindAsync(idUsuario);
            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Actualiza los campos necesarios
            usuarioExistente.Nombre = usuarioActualizado.Nombre;
            usuarioExistente.PrimerApellido = usuarioActualizado.PrimerApellido;
            usuarioExistente.SegundoApellido = usuarioActualizado.SegundoApellido;
            usuarioExistente.NombreUsuario = usuarioActualizado.NombreUsuario;
            usuarioExistente.Contrasenia = usuarioActualizado.Contrasenia;
            usuarioExistente.Colonia = usuarioActualizado.Colonia;
            usuarioExistente.Calle = usuarioActualizado.Calle;
            usuarioExistente.NumEx = usuarioActualizado.NumEx;
            usuarioExistente.Telefono = usuarioActualizado.Telefono;
            usuarioExistente.Email = usuarioActualizado.Email;

            _baseDatos.Entry(usuarioExistente).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok(usuarioExistente);
        }

        [HttpDelete]
        [Route("EliminarUsuarioCliente/{idUsuario}")]
        public async Task<IActionResult> EliminarUsuario(int idUsuario)
        {
            var usuarioExistente = await _baseDatos.Usuarios.FindAsync(idUsuario);
            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            _baseDatos.Usuarios.Remove(usuarioExistente);
            await _baseDatos.SaveChangesAsync();

            return Ok($"Usuario con ID {idUsuario} ha sido eliminado.");
        }
    }
}
