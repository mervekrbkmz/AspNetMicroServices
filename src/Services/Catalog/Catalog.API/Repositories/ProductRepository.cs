using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;


namespace  Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ICatalogContext _catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            catalogContext=_catalogContext;
        }
        public Task CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext 
                        .Products   
                        .Find(p=>true)
                        .ToListAsync();
        }
         public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext 
                        .Products   
                        .Find(p=>p.Id==id)
                        .FirstOrDefaultAsync();
        }
   public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _catalogContext 
                        .Products   
                        .Find(p=>p.Name==name)
                        .ToListAsync();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}