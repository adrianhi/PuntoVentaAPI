﻿using Microsoft.AspNetCore.Mvc;
using PuntoVenta.BLL.Services;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DTO;
using PuntoVentaAPI.Utility;


namespace PuntoVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController (IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> Lista ( )
        {
            var response = new Response<List<ProductoDTO>>();
            try
            {
                response.status = true;
                response.value = await _productService.List();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> PostProduct([FromBody] ProductoDTO product)
        {
            var response = new Response<ProductoDTO>();
            try
            {
                response.status = true;
                response.value = await _productService.Create(product);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> PutProduct ([FromBody] ProductoDTO product)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _productService.Edit(product);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id:int}")]
        public async Task<IActionResult> DeleteProduct (int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _productService.Delete(id);
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
