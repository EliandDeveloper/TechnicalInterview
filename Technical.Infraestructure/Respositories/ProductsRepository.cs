

using Technical.Domain.Entities;
using Technical.Infraestructure.Context;
using Technical.Infraestructure.Core;
using Technical.Infraestructure.Interfaces;
using Technical.Infraestructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Technical.Infraestructure.Respositories
{
    public class ProductsRepository : BaseRepository<Products, int>, IProductsRepository
    {

        private readonly ProductsContext _context;

        public ProductsRepository(ProductsContext context) : base(context)
        {
            this._context = context;
        }

        public ProductsModel GetProductsById(int Id)
        {
            return this.GetProducts().SingleOrDefault(pd => pd.ProductID == Id);
        }

        public List<ProductsModel> GetProducts()
        {
            var products = this.GetEntities()
                                .Where(pd => !pd.Eliminado)
                                .Select(pd => new ProductsModel()
                                {
                                    ProductID = pd.ProductID,
                                    ProductName = pd.ProductName,
                                    SupplierID = pd.SupplierID,
                                    CategoryID = pd.CategoryID,
                                    QuantityPerUnit = pd.QuantityPerUnit,
                                    UnitPrice = pd.UnitPrice,
                                    UnitsInStock = pd.UnitsInStock,
                                    UnitsOnOrder = pd.UnitsOnOrder,
                                    ReorderLevel = pd.ReorderLevel,
                                    Discontinued = pd.Discontinued,
                                    FechaRegistro = pd.FechaRegistro
                                }).ToList();

            return products;
        }

        public override void Save(Products entity)
        {
            base.Save(entity);
            this._context.SaveChanges();
        }

        public override void Update(Products entity)
        {
            var productsToUpdate = base.GetEntity(entity.ProductID);

            productsToUpdate.ProductName = entity.ProductName;
            productsToUpdate.SupplierID = entity.SupplierID;
            productsToUpdate.CategoryID = entity.CategoryID;
            productsToUpdate.QuantityPerUnit = entity.QuantityPerUnit;
            productsToUpdate.UnitPrice = entity.UnitPrice;
            productsToUpdate.UnitsInStock = entity.UnitsInStock;
            productsToUpdate.UnitsOnOrder = entity.UnitsOnOrder;
            productsToUpdate.ReorderLevel = entity.ReorderLevel;
            productsToUpdate.Discontinued = entity.Discontinued;
            productsToUpdate.FechaMod = entity.FechaMod;
            productsToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

            this._context.Products.Update(productsToUpdate);
            this._context.SaveChanges();
        }

        public override void Remove(Products entity)
        {
            Products products = this.GetEntity(entity.ProductID);

            products.ProductID = entity.ProductID;
            products.Eliminado = entity.Eliminado;
            products.FechaElimino = entity.FechaElimino;
            products.IdUsuarioElimino = entity.IdUsuarioElimino;

            this._context.Products.Update(products);
            this._context.SaveChanges();
        }
    }
}
