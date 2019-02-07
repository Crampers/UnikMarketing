using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Unik.Marketing.Api.Data.MongoDb.Documents
{
    public class RequestDocument
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("note")] public string Note { get; set; }

        [BsonElement("user_id")] public string UserId { get; set; }
    }
}