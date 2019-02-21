using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Unik.Marketing.Api.Data.MongoDb.Documents
{
    public class UserDocument
    {
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("email")] public string Email { get; set; }

        [BsonElement("name")] public string Name { get; set; }

        [BsonElement("password")] public string Password { get; set; }

        [BsonElement("address")] public string Address { get; set; }

        [BsonElement("zip_code")] public string ZipCode { get; set; }

        [BsonElement("criteria")] public CriteriaDocument Criteria { get; set; }
    }
}