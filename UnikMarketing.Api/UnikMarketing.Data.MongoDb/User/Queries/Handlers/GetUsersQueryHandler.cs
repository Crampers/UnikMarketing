using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.User.Queries;

namespace UnikMarketing.Data.MongoDb.User.Queries.Handlers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, ICollection<Domain.User>>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<ICollection<Domain.User>> Handle(GetUsersQuery query)
        {
            var collection = _database.GetCollection<UserDocument>(Collections.Users);
            var cursor = await collection.FindAsync(new BsonDocument());

            return _mapper.Map<ICollection<Domain.User>>(await cursor.ToListAsync());
        }
    }
}
