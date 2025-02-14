

using Technical.Application.Core;
using Technical.Application.Dtos.Products;

namespace Technical.Application.Contracts
{
    public interface IProductsService : IBaseService<ProductsDtoAdd, ProductsDtoUpdate, ProductsDtoRemove, int>
    {
    }
}
