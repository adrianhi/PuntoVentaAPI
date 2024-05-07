using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Producto> _productRepository;
        private readonly IMapper _mapper;

        public ProductService (IGenericRepository<Producto> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductoDTO>> List ( )
        {
            try {
                var productQuery = await _productRepository.Consult();
                var productList = productQuery.Include(cat => cat.IdCategoriaNavigation).ToList();
                return _mapper.Map<List<ProductoDTO>>(productList.ToList());
            } catch {
                throw;
            }
        }

        public async Task<ProductoDTO> Create (ProductoDTO product)
        {

            try
            {
                var createdProduct = await _productRepository.Create(_mapper.Map<Producto>(product));
                if (createdProduct.IdProducto == 0) 
                    throw new TaskCanceledException("No se pudo crear");
                
                return _mapper.Map<ProductoDTO>(createdProduct);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit (ProductoDTO product)
        {
            try
            {
                var productModel =_mapper.Map<Producto>(product);
                var productFinded = await _productRepository.Get(
                    u => u.IdProducto == productModel.IdProducto
                    );
                if (productModel == null)
                    throw new TaskCanceledException("El producto no existe");


                productFinded.Codigo = productModel.Codigo;
                productFinded.Nombre = productModel.Nombre;
                productFinded.PrecioVenta= productModel.PrecioVenta;
                productFinded.Estado= productModel.Estado;
                productFinded.Existencia= productModel.Existencia;
                productFinded.Stock = productModel.Stock;
                productFinded.IdCategoria = productModel.IdCategoria;

                bool response = await _productRepository.Edit(productFinded);
                if (response)
                    throw new TaskCanceledException("No se pudo editar el producto");

                return response;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete (int id)
        {
            try
            {
              var productFinded = await _productRepository.Get(
              u => u.IdProducto ==id
              );

                if (productFinded == null)
                {
                    throw new TaskCanceledException("El producto no existe");
                }

                bool response = await _productRepository.Delete(productFinded);
                if (response)
                    throw new TaskCanceledException("No se pudo eliminar el producto");

                return response;
            }
            catch
            {

            throw ;
            }
        }


    }
}
