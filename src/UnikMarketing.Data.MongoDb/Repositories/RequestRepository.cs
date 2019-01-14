using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UnikMarketing.Domain;
using UnikMarketing.Domain.Repositories;

namespace UnikMarketing.Data.MongoDb.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private const string CollectionName = "requests";
        private readonly IMongoDatabase _database;

        public RequestRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Request> Create(Request request)
        {
            var collection = _database.GetCollection<Request>(CollectionName);
            await collection.InsertOneAsync(request);

            return request;
        }

        public async Task<ICollection<Request>> GetAll()
        {
            var collection = _database.GetCollection<Request>(CollectionName);
            var cursor = await collection.FindAsync(new BsonDocument());

            return await cursor.ToListAsync();
        }

        public async Task<Request> Get(int id)
        {
            var collection = _database.GetCollection<Request>(CollectionName);
            var cursor = await collection.FindAsync(Builders<Request>.Filter.Eq(nameof(Request.Id), id));

            return await cursor.FirstAsync();
        }

        public Task<Request> Update(Request request)
        {
            var collection = _database.GetCollection<Request>(CollectionName);

            return collection.FindOneAndUpdateAsync(
                Builders<Request>.Filter.Eq(nameof(Request.Id), request.Id),
                Builders<Request>.Update.Set(nameof(Request.Note), request.Note)
            );
        }

        public Task Delete(Request request)
        {
            return Delete(request.Id);
        }

        public Task Delete(int id)
        {
            return _database
                .GetCollection<Request>(CollectionName)
                .FindOneAndDeleteAsync(Builders<Request>.Filter.Eq(nameof(Request.Id), id));
        }
    }
}
