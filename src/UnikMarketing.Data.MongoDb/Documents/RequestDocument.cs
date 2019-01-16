using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace UnikMarketing.Data.MongoDb.Documents
{
    public class RequestDocument
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        public string Note { get; set; }
    }
}