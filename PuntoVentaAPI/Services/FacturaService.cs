using Microsoft.EntityFrameworkCore;
using PuntoVentaAPI.Models;

namespace PuntoVentaAPI.Services
{
    public class FacturaService
    {
        private readonly PuntoVentasContext _context;

        public FacturaService (PuntoVentasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetFacturas ( ) => await _context.Facturas.ToListAsync();


        public async Task<bool> CrearFactura (int idVenta, int idTipoTransaccion, int idTransaccion, DateTime fechaEmision, int idCliente, decimal total, decimal totalPagado, string estadoPago)
        {
            try
            {
                // Crea una nueva factura
                var nuevaFactura = new Factura
                {
                    IdVenta = idVenta,
                    IdTipoTransaccion= idTipoTransaccion,
                    IdTransaccion = idTransaccion,
                    FechaEmision = fechaEmision,
                    IdCliente = idCliente,
                    Total = total,
                    TotalPagado = totalPagado,
                    EstadoPago = estadoPago
                };

          
                _context.Facturas.Add(nuevaFactura);
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, logging
                Console.WriteLine($"Error al crear la factura: {ex.Message}");
                return false; // La factura no se pudo crear
            }
        }
    }

}
