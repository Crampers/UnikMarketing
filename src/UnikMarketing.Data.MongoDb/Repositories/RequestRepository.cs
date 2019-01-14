using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Domain;
using UnikMarketing.Domain.Repositories;

namespace UnikMarketing.Data.MongoDb.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private const string CollectionName = "requests";
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public RequestRepository(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Request> Create(Request request)
        {
            var document = _mapper.Map<RequestDocument>(request);
            var collection = _database.GetCollection<RequestDocument>(CollectionName);

            await collection.InsertOneAsync(document);

            return _mapper.Map<Request>(document);
        }

        public async Task<ICollection<Request>> GetAll()
        {
            var collection = _database.GetCollection<RequestDocument>(CollectionName);
            var cursor = await collection.FindAsync(new BsonDocument());

            return _mapper.Map<ICollection<Request>>(await cursor.ToListAsync());
        }

        public async Task<Request> Get(string id)
        {
            var collection = _database.GetCollection<RequestDocument>(CollectionName);
            var cursor = await collection.FindAsync(Builders<RequestDocument>.Filter.Eq(
                nameof(RequestDocument.Id), 
                id
            ));

            return _mapper.Map<Request>(await cursor.FirstAsync());
        }

        public async Task<Request> Update(Request request)
        {
            var collection = _database.GetCollection<RequestDocument>(CollectionName);

            return _mapper.Map<Request>(await collection.FindOneAndUpdateAsync(
                Builders<RequestDocument>.Filter.Eq(nameof(RequestDocument.Id), request.Id),
                Builders<RequestDocument>.Update.Set(nameof(RequestDocument.Note), request.Note)
            ));
        }

        public Task Delete(Request request)
        {
            return Delete(request.Id);
        }

        public async Task Delete(string id)
        {
            _mapper.Map<Request>(await _database
                .GetCollection<RequestDocument>(CollectionName)
                .FindOneAndDeleteAsync(Builders<RequestDocument>.Filter.Eq(
                    nameof(RequestDocument.Id), 
                    id
                )));
        }
    }
}
