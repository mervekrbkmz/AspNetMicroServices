using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
  public class CatalogContext : ICatalogContext
  {
    public CatalogContext(IConfiguration _configuration)
    {
      //Db bring using
      var client = new MongoClient(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var database = client.GetDatabase(_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

      //for collection using 
      Products = database.GetCollection<Product>(_configuration.GetValue<string>("DatabaseSettings:CollectionName"));
      CatalogContextSeed.SeedData(Products); //db ilk çalıştırıldığında dbye 

    }
    public IMongoCollection<Product> Products {get;}
  }
}
