using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Unik.Marketing.Api.Data.MongoDb;
using Unik.Marketing.Api.Data.MongoDb.Documents;

namespace Unik.Marketing.Api.Business.User.Queries.Handlers
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
            var builder = Builders<RequestDocument>.Filter;

            if (query.Ids?.Count > 0)
            {
                if (query.Ids.Count == 1)
                {
                    builder.Eq(nameof(UserDocument.Id), query.Ids.First());
                }
                else
                {
                    builder.In(nameof(UserDocument.Id), query.Ids);
                }
            }

            var cursor = await collection.FindAsync(builder.ToBsonDocument());

            return _mapper.Map<ICollection<Domain.User>>(await cursor.ToListAsync());
        }
    }
}