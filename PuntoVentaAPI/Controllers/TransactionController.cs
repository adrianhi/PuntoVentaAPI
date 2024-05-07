using Microsoft.AspNetCore.Mvc;
using PuntoVenta.BLL.Services;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DTO;
using PuntoVentaAPI.Utility;

namespace PuntoVentaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransaccionService _transaccionService;

        public TransactionController (ITransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] TransaccionDTO transanction)
        {
            var response = new Response<TransaccionDTO>();
            try
            {
                response.status = true;
                response.value = await _transaccionService.Register(transanction);
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
