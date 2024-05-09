using Microsoft.AspNetCore.Mvc;
using PuntoVenta.BLL.Services;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DTO;
using PuntoVentaAPI.Utility;

namespace PuntoVentaAPI.Controllers
{
    public class cxcController : Controller 
    {
        private readonly ICxCService _cxcService;

        public cxcController (ICxCService cxcService)
        {
            _cxcService = cxcService;
        }



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] CxCDTO cxc)
        {
            var response = new Response<CxCDTO>();
            try
            {
                response.status = true;
                response.value = await _cxcService.Register(cxc);
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
