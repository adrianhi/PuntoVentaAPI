using Microsoft.AspNetCore.Mvc;
using PuntoVenta.BLL.Services;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DTO;
using PuntoVentaAPI.Utility;

namespace PuntoVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly IVentaService _saleService;

        public SaleController (IVentaService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] VentaDTO sale)
        {
            var response = new Response<VentaDTO>();
            try
            {
                response.status = true;
                response.value = await _saleService.Register(sale);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

    }
}
