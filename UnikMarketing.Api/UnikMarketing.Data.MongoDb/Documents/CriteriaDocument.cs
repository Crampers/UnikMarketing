using MongoDB.Bson.Serialization.Attributes;

namespace UnikMarketing.Data.MongoDb.Documents
{
    internal class CriteriaDocument
    {
        [BsonElement("size_from")] public decimal SizeFrom { get; set; }

        [BsonElement("size_to")] public decimal SizeTo { get; set; }

        [BsonElement("price_from")] public decimal PriceFrom { get; set; }

        [BsonElement("price_to")] public decimal PriceTo { get; set; }

        [BsonElement("floor_from")] public int FloorFrom { get; set; }

        [BsonElement("floor_to")] public int FloorTo { get; set; }
    }
}