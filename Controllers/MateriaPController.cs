using DecoArtp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecoArtp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPController : ControllerBase
    {
        private readonly DeskArtContext _baseDatos;

        public MateriaPController(DeskArtContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // Método para obtener la lista de todos los productos
        [HttpGet]
        [Route("ListaMP")]
        public async Task<IActionResult> Lista()
        {
            var listaMP = await _baseDatos.MateriaPs.ToListAsync();
            return Ok(listaMP);
        }
        [HttpPost]
        [Route("AgregarMP")]
        public async Task<IActionResult> AgregarMP([FromBody] MateriaP nuevoMP)
        {
            if (nuevoMP == null)
            {
                return BadRequest("Datos de mp inválidos.");
            }

            // Validaciones adicionales si es necesario

            await _baseDatos.MateriaPs.AddAsync(nuevoMP);
            await _baseDatos.SaveChangesAsync();

            return Ok(nuevoMP);
        }
        [HttpPut]
        [Route("EditarMP/{idMateriaP}")]
        public async Task<IActionResult> EditarMP(int idMateriaP, [FromBody] MateriaP materiaMPActualizado)
        {
            if (materiaMPActualizado == null || idMateriaP != materiaMPActualizado.IdMateriaP)
            {
                return BadRequest("Datos de MP no son validos o ID no coincide.");
            }

            var mpExistente = await _baseDatos.MateriaPs.FindAsync(idMateriaP);
            if (mpExistente == null)
            {
                return NotFound("Materia prima no encontrada.");
            }

            // Actualiza los campos necesarios
            mpExistente.Nombre= mpExistente.Nombre;
            mpExistente.Medida = mpExistente.Medida;
           

            _baseDatos.Entry(mpExistente).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok(mpExistente);
        }

        [HttpDelete]
        [Route("EliminarMP/{idMateriaP}")]
        public async Task<IActionResult> EliminarUsuario(int idMateriaP)
        {
            var mpExistente = await _baseDatos.MateriaPs.FindAsync();
            if (mpExistente == null)
            {
                return NotFound("Materia Prima no encontrada.");
            }

            _baseDatos.MateriaPs.Remove(mpExistente);
            await _baseDatos.SaveChangesAsync();

            return Ok($"Materia prima con ID {idMateriaP} ha sido eliminada.");
        }
    }
}
