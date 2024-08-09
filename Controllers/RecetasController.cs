using Microsoft.AspNetCore.Mvc;
using DecoArtp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DecoArtp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly DeskArtContext _context;

        public RecetasController(DeskArtContext context)
        {
            _context = context;
        }

        // GET: api/Recetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recetum>>> GetRecetas()
        {
            return await _context.Receta
                .Include(r => r.MateriaPIdMateriaPNavigation)
                .Include(r => r.ProductoIdProductoNavigation)
                .ToListAsync();
        }

        // GET: api/Recetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recetum>> GetReceta(int id)
        {
            var receta = await _context.Receta
                .Include(r => r.MateriaPIdMateriaPNavigation)
                .Include(r => r.ProductoIdProductoNavigation)
                .FirstOrDefaultAsync(r => r.IdReceta == id);

            if (receta == null)
            {
                return NotFound();
            }

            return receta;
        }

        // POST: api/Recetas
        [HttpPost]
        public async Task<ActionResult<Recetum>> PostReceta(Recetum receta)
        {
            _context.Receta.Add(receta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceta), new { id = receta.IdReceta }, receta);
        }

        // PUT: api/Recetas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta(int id, Recetum receta)
        {
            if (id != receta.IdReceta)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Recetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(int id)
        {
            var receta = await _context.Receta.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Receta.Remove(receta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecetaExists(int id)
        {
            return _context.Receta.Any(e => e.IdReceta == id);
        }
    }
}
