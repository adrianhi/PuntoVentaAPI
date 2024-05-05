using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntoVentaAPI.Models;

namespace PuntoVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesCtasxcobrarsController : ControllerBase
    {
        private readonly PuntoVentasContext _context;

        public DetallesCtasxcobrarsController(PuntoVentasContext context)
        {
            _context = context;
        }

        // GET: api/DetallesCtasxcobrars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesCtasxcobrar>>> GetDetallesCtasxcobrars()
        {
            return await _context.DetallesCtasxcobrars.ToListAsync();
        }

        // GET: api/DetallesCtasxcobrars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesCtasxcobrar>> GetDetallesCtasxcobrar(int id)
        {
            var detallesCtasxcobrar = await _context.DetallesCtasxcobrars.FindAsync(id);

            if (detallesCtasxcobrar == null)
            {
                return NotFound();
            }

            return detallesCtasxcobrar;
        }

        // PUT: api/DetallesCtasxcobrars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesCtasxcobrar(int id, DetallesCtasxcobrar detallesCtasxcobrar)
        {
            if (id != detallesCtasxcobrar.IdDetalleCxC)
            {
                return BadRequest();
            }

            _context.Entry(detallesCtasxcobrar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesCtasxcobrarExists(id))
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

        // POST: api/DetallesCtasxcobrars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesCtasxcobrar>> PostDetallesCtasxcobrar(DetallesCtasxcobrar detallesCtasxcobrar)
        {
            _context.DetallesCtasxcobrars.Add(detallesCtasxcobrar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesCtasxcobrar", new { id = detallesCtasxcobrar.IdDetalleCxC }, detallesCtasxcobrar);
        }

        // DELETE: api/DetallesCtasxcobrars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesCtasxcobrar(int id)
        {
            var detallesCtasxcobrar = await _context.DetallesCtasxcobrars.FindAsync(id);
            if (detallesCtasxcobrar == null)
            {
                return NotFound();
            }

            _context.DetallesCtasxcobrars.Remove(detallesCtasxcobrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesCtasxcobrarExists(int id)
        {
            return _context.DetallesCtasxcobrars.Any(e => e.IdDetalleCxC == id);
        }
    }
}
