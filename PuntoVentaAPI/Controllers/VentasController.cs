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
    public class VentasController : ControllerBase
    {
        private readonly PuntoVentasContext _context;
        private readonly ProductController productController;
        private readonly DetallesVentasController detallesVentaController;
        public VentasController(PuntoVentasContext context)
        {
            _context = context;
            productController= new ProductController(_context);
            detallesVentaController= new DetallesVentasController(_context);
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaestroVenta>>> GetMaestroVentas()
        {
            return await _context.MaestroVentas.ToListAsync();
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaestroVenta>> GetMaestroVenta(int id)
        {
            var maestroVenta = await _context.MaestroVentas.FindAsync(id);

            if (maestroVenta == null)
            {
                return NotFound();
            }

            return maestroVenta;
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaestroVenta(int id, MaestroVenta maestroVenta)
        {
            if (id != maestroVenta.IdVenta)
            {
                return BadRequest();
            }

            _context.Entry(maestroVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroVentaExists(id))
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

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaestroVenta>> PostMaestroVenta (MaestroVenta maestroVenta)
        {
            _context.MaestroVentas.Add(maestroVenta);
            await _context.SaveChangesAsync();
            foreach (var item in maestroVenta.DetallesVenta)
            {
                await UpdateProductExistence(item.IdProducto ?? 0, item.Cantidad ?? 0);
            }
            return CreatedAtAction("GetMaestroVenta", new { id = maestroVenta.IdVenta }, maestroVenta);
        }

        private async Task UpdateProductExistence (int productId, int quantitySold)
        {
            try
            {
                Producto producto = await productController.GetProducto(productId);
                if (producto != null)
                {
                    if (producto.Existencia >= quantitySold)
                    {
                        producto.Existencia -= quantitySold;
                        if (producto.Existencia == 0)
                        {
                            producto.Estado = "No disponible";
                        }
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("La cantidad vendida es mayor que la existencia del producto.");
                    }
                }
                else
                {
                    throw new Exception("El producto no fue encontrado en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la existencia del producto: {ex.Message}");
            }
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaestroVenta(int id)
        {
            var maestroVenta = await _context.MaestroVentas.FindAsync(id);
            if (maestroVenta == null)
            {
                return NotFound();
            }

            _context.MaestroVentas.Remove(maestroVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaestroVentaExists(int id)
        {
            return _context.MaestroVentas.Any(e => e.IdVenta == id);
        }
    }
}
