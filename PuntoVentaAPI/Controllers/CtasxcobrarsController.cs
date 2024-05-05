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
    public class CtasxcobrarsController : ControllerBase
    {
        private readonly PuntoVentasContext _context;

        public CtasxcobrarsController(PuntoVentasContext context)
        {
            _context = context;
        }

        // GET: api/Ctasxcobrars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaestroCtasxcobrar>>> GetMaestroCtasxcobrars()
        {
            return await _context.MaestroCtasxcobrars.ToListAsync();
        }

        // GET: api/Ctasxcobrars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaestroCtasxcobrar>> GetMaestroCtasxcobrar(int id)
        {
            var maestroCtasxcobrar = await _context.MaestroCtasxcobrars.FindAsync(id);

            if (maestroCtasxcobrar == null)
            {
                return NotFound();
            }

            return maestroCtasxcobrar;
        }

        // PUT: api/Ctasxcobrars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaestroCtasxcobrar(int id, MaestroCtasxcobrar maestroCtasxcobrar)
        {
            if (id != maestroCtasxcobrar.IdCxC)
            {
                return BadRequest();
            }

            _context.Entry(maestroCtasxcobrar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroCtasxcobrarExists(id))
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

        // POST: api/Ctasxcobrars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaestroCtasxcobrar>> PostMaestroCtasxcobrar(MaestroCtasxcobrar maestroCtasxcobrar)
        {
            _context.MaestroCtasxcobrars.Add(maestroCtasxcobrar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaestroCtasxcobrar", new { id = maestroCtasxcobrar.IdCxC }, maestroCtasxcobrar);
        }

        // DELETE: api/Ctasxcobrars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaestroCtasxcobrar(int id)
        {
            var maestroCtasxcobrar = await _context.MaestroCtasxcobrars.FindAsync(id);
            if (maestroCtasxcobrar == null)
            {
                return NotFound();
            }

            _context.MaestroCtasxcobrars.Remove(maestroCtasxcobrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaestroCtasxcobrarExists(int id)
        {
            return _context.MaestroCtasxcobrars.Any(e => e.IdCxC == id);
        }
    }
}
