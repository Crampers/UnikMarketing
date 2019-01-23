using System;
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
    public class UserRepository : IUserRepository
    {
        private const string CollectionName = "users";
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMapper _mapper;

        public UserRepository(IMongoDatabase mongoDatabase, IMapper mapper)
        {
            _mongoDatabase = mongoDatabase;
            _mapper = mapper;
        }

        public async Task<User> Create(User user)
        {
            var document = _mapper.Map<UserDocument>(user);
            var collection = _mongoDatabase.GetCollection<UserDocument>(CollectionName);

            await collection.InsertOneAsync(document);

            return _mapper.Map<User>(document);
        }

        public async Task<ICollection<User>> GetAll()
        {
            var collection = _mongoDatabase.GetCollection<UserDocument>(CollectionName);
            var cursor = await collection.FindAsync(new BsonDocument());

            return _mapper.Map<ICollection<User>>(await cursor.ToListAsync());
        }

        public async Task<User> Get(string id)
        {
            var collection = _mongoDatabase.GetCollection<UserDocument>(CollectionName);
            var cursor = await collection.FindAsync(Builders<UserDocument>.Filter.Eq(
                nameof(UserDocument.Id), 
                id
            ));

            return _mapper.Map<User>(await cursor.FirstOrDefaultAsync());
        }

        public async Task<User> Update(User user)
        {
            var document = _mapper.Map<UserDocument>(user);
            var collection = _mongoDatabase.GetCollection<UserDocument>(CollectionName);
            var projection = await collection.FindOneAndUpdateAsync(
                Builders<UserDocument>.Filter.Eq(nameof(UserDocument.Id), document.Id), 
                Builders<UserDocument>.Update
                    .Set(nameof(UserDocument.Address), document.Address)
                    .Set(nameof(UserDocument.Criteria), document.Criteria)
                    .Set(nameof(UserDocument.Email), document.Email)
                    .Set(nameof(UserDocument.Name), document.Name)
                    .Set(nameof(UserDocument.Password), document.Password)
                    .Set(nameof(UserDocument.ZipCode), document.ZipCode)
            );

            return _mapper.Map<User>(projection);
        }

        public async Task Delete(User user)
        {
            await Delete(user.Id);
        }

        public async Task Delete(string id)
        {
            var collection = _mongoDatabase.GetCollection<UserDocument>(CollectionName);

            await collection.FindOneAndDeleteAsync(Builders<UserDocument>.Filter.Eq(
                nameof(UserDocument.Id), 
                id
            ));
        }
    }
}