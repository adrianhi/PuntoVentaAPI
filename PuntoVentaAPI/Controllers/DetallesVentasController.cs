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

     
        // POST: api/DetallesVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesVenta>> PostDetallesVenta(DetallesVenta detallesVenta)
        {
            _context.DetallesVentas.Add(detallesVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesVenta", new { id = detallesVenta.IdDetallesVentas }, detallesVenta);
        }

       
        private bool DetallesVentaExists(int id)
        {
            return _context.DetallesVentas.Any(e => e.IdDetallesVentas == id);
        }
    }
}
