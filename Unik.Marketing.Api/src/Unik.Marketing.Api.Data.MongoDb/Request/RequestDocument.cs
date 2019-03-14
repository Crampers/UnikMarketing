﻿using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Unik.Marketing.Api.Data.MongoDb.Request
{
    public class RequestDocument
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("aggregate_id")] public Guid AggregateId { get; set; }

        [BsonElement("note")] public string Note { get; set; }

        [BsonElement("user_id")] public string UserId { get; set; }
    }
}