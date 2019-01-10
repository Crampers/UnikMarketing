using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UnikMarketing.Domain;
using UnikMarketing.Domain.Repositories;

namespace UnikMarketing.Data.MongoDb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string CollectionName = "Users";
        private readonly IMongoDatabase _mongoDatabase;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<User> Create(User user)
        {
            var collection = _mongoDatabase.GetCollection<User>(CollectionName);
            await collection.InsertOneAsync(user);

            return user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var collection = _mongoDatabase.GetCollection<User>(CollectionName);
            var cursor = await collection.FindAsync(new BsonDocument());

            return await cursor.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            var collection = _mongoDatabase.GetCollection<User>(CollectionName);
            var cursor = await collection.FindAsync(Builders<User>.Filter.Eq(nameof(User.Id), id));

            return await cursor.FirstAsync();
        }

        public async Task<User> Update(User user)
        {
            var collection = _mongoDatabase.GetCollection<User>(CollectionName);
            var projection = await collection.FindOneAndUpdateAsync(
                Builders<User>.Filter.Eq(nameof(User.Id), user.Id), 
                Builders<User>.Update
                    .Set(nameof(User.Address), user.Address)
                    .Set(nameof(User.Criteria), user.Criteria)
                    .Set(nameof(User.Email), user.Email)
                    .Set(nameof(User.Name), user.Name)
                    .Set(nameof(User.Password), user.Password)
                    .Set(nameof(User.Requests), user.Requests)
                    .Set(nameof(User.ZipCode), user.ZipCode)
            );

            return projection;
        }

        public async Task Delete(User user)
        {
            await Delete(user.Id);
        }

        public async Task Delete(int id)
        {
            var collection = _mongoDatabase.GetCollection<User>(CollectionName);
            await collection.FindOneAndDeleteAsync(Builders<User>.Filter.Eq(nameof(User.Id), id));
        }
    }
}