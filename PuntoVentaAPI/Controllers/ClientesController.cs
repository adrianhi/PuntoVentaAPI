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
    public class ClientesController : ControllerBase
    {
        private readonly PuntoVentasContext _context;

        public ClientesController(PuntoVentasContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaestroCliente>>> GetMaestroClientes()
        {
            return await _context.MaestroClientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaestroCliente>> GetMaestroCliente(int id)
        {
            var maestroCliente = await _context.MaestroClientes.FindAsync(id);

            if (maestroCliente == null)
            {
                return NotFound();
            }

            return maestroCliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaestroCliente(int id, MaestroCliente maestroCliente)
        {
            if (id != maestroCliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(maestroCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaestroCliente>> PostMaestroCliente(MaestroCliente maestroCliente)
        {
            _context.MaestroClientes.Add(maestroCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaestroClienteExists(maestroCliente.IdCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaestroCliente", new { id = maestroCliente.IdCliente }, maestroCliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaestroCliente(int id)
        {
            var maestroCliente = await _context.MaestroClientes.FindAsync(id);
            if (maestroCliente == null)
            {
                return NotFound();
            }

            _context.MaestroClientes.Remove(maestroCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaestroClienteExists(int id)
        {
            return _context.MaestroClientes.Any(e => e.IdCliente == id);
        }
    }
}
