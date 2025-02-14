
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Technical.Application.Contracts;
using Technical.Application.Core;
using Technical.Application.Dtos.Products;
using Technical.Infraestructure.Interfaces;
using Technical.Domain.Entities;
using Technical.Application.Extentions;
using Technical.Application.Exceptions;

namespace Technical.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        private readonly ILogger<ProductsService> logger;
        private readonly IConfiguration configuration;

        public ProductsService(IProductsRepository productsRepository,
                               ILogger<ProductsService> logger, IConfiguration configuration)
        {
            this.productsRepository = productsRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.productsRepository.GetProducts();
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = $"Error obteniendo los productos.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.productsRepository.GetProductsById(Id);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(ProductsDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Products product = new Products()
                {
                    ProductID = dtoRemove.ProductID,
                    Eliminado = dtoRemove.Eliminado,
                    IdUsuarioElimino = dtoRemove.ChangeUser,
                    FechaElimino = dtoRemove.ChangeDate

                };

                this.productsRepository.Remove(product);

                result.Message = "Producto eliminado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(ProductsDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validresult = dtoAdd.IsProductValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }


                Products product = new Products()
                {
                    ProductName = dtoAdd.ProductName,
                    QuantityPerUnit = dtoAdd.QuantityPerUnit,
                    UnitPrice = dtoAdd.UnitPrice,
                    UnitsInStock = dtoAdd.UnitsInStock,
                    UnitsOnOrder = dtoAdd.UnitsOnOrder,
                    FechaRegistro = dtoAdd.ChangeDate,
                    IdUsuarioCreacion = dtoAdd.ChangeUser,
                };

                this.productsRepository.Save(product);

                result.Message = "Producto guardado satisfactoriamente";
            }
            catch (ProductsServiceException pse)
            {
                result.Success = false;
                result.Message = pse.Message;
                this.logger.LogError($"{result.Message}", pse.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error guardando el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(ProductsDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validresult = dtoUpdate.IsProductValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }


                Products product = new Products()
                {
                    ProductID = dtoUpdate.ProductID,
                    ProductName = dtoUpdate.ProductName,
                    QuantityPerUnit = dtoUpdate.QuantityPerUnit,
                    UnitPrice = dtoUpdate.UnitPrice,
                    UnitsInStock = dtoUpdate.UnitsInStock,
                    UnitsOnOrder = dtoUpdate.UnitsOnOrder,
                    FechaRegistro = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser,
                };

                this.productsRepository.Update(product);

                result.Message = "Producto actualizado satisfactoriamente";
            }
            catch (ProductsServiceException pse)
            {
                result.Success = false;
                result.Message = pse.Message;
                this.logger.LogError($"{result.Message}", pse.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

    }
}
