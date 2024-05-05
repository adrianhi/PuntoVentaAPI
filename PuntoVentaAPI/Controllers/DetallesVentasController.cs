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
    public class DetallesVentasController : ControllerBase
    {
        private readonly PuntoVentasContext _context;
        public DetallesVentasController(PuntoVentasContext context)
        {
            _context = context;
            
        }

        // GET: api/DetallesVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesVenta>>> GetDetallesVentas()
        {
            return await _context.DetallesVentas.ToListAsync();
        }

        // GET: api/DetallesVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesVenta>> GetDetallesVenta(int id)
        {
            var detallesVenta = await _context.DetallesVentas.FindAsync(id);

            if (detallesVenta == null)
            {
                return NotFound();
            }

            return detallesVenta;
        }

        // PUT: api/DetallesVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesVenta(int id, DetallesVenta detallesVenta)
        {
            if (id != detallesVenta.IdDetallesVentas)
            {
                return BadRequest();
            }

            _context.Entry(detallesVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesVentaExists(id))
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

        // POST: api/DetallesVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<DetallesVenta>>> PostDetallesVenta (List<DetallesVenta> detallesVenta)
        {
            try
            {
                foreach (var detalle in detallesVenta)
                {
                    _context.DetallesVentas.Add(detalle);
                }

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDetallesVenta", new { id = detallesVenta[0].IdDetallesVentas }, detallesVenta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear los detalles de venta: {ex.Message}");
            }
        }


        // DELETE: api/DetallesVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesVenta(int id)
        {
            var detallesVenta = await _context.DetallesVentas.FindAsync(id);
            if (detallesVenta == null)
            {
                return NotFound();
            }

            _context.DetallesVentas.Remove(detallesVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesVentaExists(int id)
        {
            return _context.DetallesVentas.Any(e => e.IdDetallesVentas == id);
        }


    }
}
