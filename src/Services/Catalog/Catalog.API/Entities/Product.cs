using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
  public class Product //mongodb-collection
  {
    [BsonId] //bsonid documentin mongodbden alındığı anlamına gelir. bson kullandım.
    [BsonRepresentation(BsonType.ObjectId)] //mongodb de id yi objectid olarak kullanmak istiyorum.
    public string Id { get; set; }
    [BsonElement("Name")] //attribute ekledim.
    public string Name { get; set; }
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }

  }
}
