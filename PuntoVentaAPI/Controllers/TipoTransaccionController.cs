using Microsoft.AspNetCore.Mvc;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DTO;
using PuntoVentaAPI.Utility;

namespace PuntoVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransaccionController : Controller
    {
        
        private readonly  ITipoTransaccionService _tipoTransaccionService;

        public TipoTransaccionController (ITipoTransaccionService tipoTransaccionService)
        {
            _tipoTransaccionService = tipoTransaccionService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] TipoTransaccionDTO transanctionType)
        {
            var response = new Response<TipoTransaccionDTO>();
            try
            {
                response.status = true;
                response.value = await _tipoTransaccionService.Register(transanctionType);
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
