

using Technical.Application.Core;
using Technical.Application.Exceptions;
using Technical.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Technical.Application.Extentions
{
    public static class ValidationsProductsExceptions
    {
        public static ServiceResult IsProductValid(this ProductsDtoBase productsDto, IConfiguration configuration)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(productsDto.ProductName))
                throw new ProductsServiceException(configuration["MensajesValidaciones:ProductNameRequerido"]);

            if (productsDto.ProductName.Length > 40)
                throw new ProductsServiceException(configuration["MensajesValidaciones:ProductNameLongitud"]);

            if (productsDto.QuantityPerUnit.Length > 20)
                throw new ProductsServiceException(configuration["MensajesValidaciones:QuantityPerUnitLongitud"]);


            return result;
        }
    }
}
