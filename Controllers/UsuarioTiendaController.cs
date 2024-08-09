using DecoArtp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecoArtp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioTiendaController : ControllerBase
    {
        private readonly DeskArtContext _baseDatos;

        public UsuarioTiendaController(DeskArtContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // Método para obtener la lista de todos los productos
        [HttpGet]
        [Route("ListaUsuariosTienda")]
        public async Task<IActionResult> Lista()
        {
            var listaUsuariosTiendum = await _baseDatos.UsuarioTienda.ToListAsync();
            return Ok(listaUsuariosTiendum);
        }
        [HttpPost]
        [Route("AgregarUsuarioTienda")]
        public async Task<IActionResult> AgregarUsuario([FromBody] UsuarioTiendum nuevoUsuario)
        {
            if (nuevoUsuario == null)
            {
                return BadRequest("Datos de usuario inválidos.");
            }

            // Validaciones adicionales si es necesario

            await _baseDatos.UsuarioTienda.AddAsync(nuevoUsuario);
            await _baseDatos.SaveChangesAsync();

            return Ok(nuevoUsuario);
        }
        [HttpPut]
        [Route("EditarUsuarioTienda/{idUsuarioTienda}")]
        public async Task<IActionResult> EditarUsuarioTienda(int idUsuarioTienda, [FromBody] UsuarioTiendum usuarioActualizado)
        {
            if (usuarioActualizado == null || idUsuarioTienda != usuarioActualizado.IdUsuarioTienda)
            {
                return BadRequest("Datos de usuario inválidos o ID no coincide.");
            }

            var usuarioExistente = await _baseDatos.UsuarioTienda.FindAsync(idUsuarioTienda);
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
            usuarioExistente.Telefono = usuarioActualizado.Telefono;
            usuarioExistente.Email = usuarioActualizado.Email;
            usuarioExistente.Rol = usuarioActualizado.Rol;
            usuarioExistente.Estatus = usuarioActualizado.Estatus;

            _baseDatos.Entry(usuarioExistente).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok(usuarioExistente);
        }

        [HttpDelete]
        [Route("EliminarUsuarioTienda/{idUsuarioTienda}")]
        public async Task<IActionResult> EliminarUsuario(int idUsuarioTienda)
        {
            var usuarioExistente = await _baseDatos.UsuarioTienda.FindAsync(idUsuarioTienda);
            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            _baseDatos.UsuarioTienda
                .Remove(usuarioExistente);
            await _baseDatos.SaveChangesAsync();

            return Ok($"Usuario con ID {idUsuarioTienda} ha sido eliminado.");
        }
    }
}