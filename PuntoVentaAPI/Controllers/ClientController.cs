using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DTO;
using PuntoVentaAPI.Utility;

namespace PuntoVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> List ( )
        {
            var response = new Response<List<ClientDTO>>();
            try
            {
                response.status = true;
                response.value = await _clientService.List();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
                return Ok(response);
        }

        [HttpPost]
        [Route("CreateClient")]
        public async Task<IActionResult> PostClient ([FromBody] ClientDTO client)
        {
            var response = new Response<ClientDTO>();
            try
            {
                response.status = true;
                response.value = await _clientService.Create(client);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateClient")]
        public async Task<IActionResult> PutClient ([FromBody] ClientDTO client)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _clientService.Edit(client);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteClient/{id:int}")]
        public async Task<IActionResult> DeleteClient (int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _clientService.Delete(id);
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
