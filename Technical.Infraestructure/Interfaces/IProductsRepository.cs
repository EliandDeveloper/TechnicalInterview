
using Technical.Domain.Repository;
using Technical.Domain.Entities;
using Technical.Infraestructure.Models;
using System.Collections.Generic;

namespace Technical.Infraestructure.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Products, int>
    {
        List<ProductsModel> GetProducts();
        ProductsModel GetProductsById(int Id);
    }
}
