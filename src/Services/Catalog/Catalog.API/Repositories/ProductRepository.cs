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
        public async Task CreateProduct(Product product)
        {
        await _catalogContext.Products.InsertOneAsync(product);
        }

        public Task<bool> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Product>> GetProductCategory(string categoryName)
        { 
              FilterDefinition<Product> filter= Builders<Product>.Filter.Eq(p=>p.Category,categoryName);
              return await _catalogContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
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
             //FilterDefinition:MongoDB'de belirli bir koşula uyan belgeleri filtrelemek için kullanılır
             //ElemMatch:eşleşip eşleşmediğini kontrol eder basit sorgularda gerek olmaz,equal kullanılmalı.
             //eq kullanmak iyidir çünkü eq ayrıca mevcut olup olmadığını da arar.
            FilterDefinition<Product> filter= Builders<Product>.Filter.Eq(p=>p.Name,name);
            return await _catalogContext 
                        .Products   
                        .Find(filter)
                        .ToListAsync();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        // public async Task<bool> UpdateProduct(Product product)
        // {
        //    var updateResult=await _catalogContext.Products.
        // }
    }
}