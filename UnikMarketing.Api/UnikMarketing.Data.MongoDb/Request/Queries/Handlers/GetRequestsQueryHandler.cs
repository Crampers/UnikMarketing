using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.Request.Queries;

namespace UnikMarketing.Data.MongoDb.Request.Queries.Handlers
{
    public class GetRequestsQueryHandler : IQueryHandler<GetRequestsQuery, ICollection<Domain.Request>>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public GetRequestsQueryHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<ICollection<Domain.Request>> Handle(GetRequestsQuery query)
        {
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);
            var builder = Builders<RequestDocument>.Filter;

            if (query.Ids?.Count > 0)
            {
                if (query.Ids.Count == 1)
                {
                    builder.Eq(nameof(RequestDocument.Id), query.Ids.First());
                }
                else
                {
                    builder.In(nameof(RequestDocument.Id), query.Ids);
                }
            }

            if (query.UserIds?.Count > 0)
            {
                if (query.UserIds.Count == 1)
                {
                    builder.Eq(nameof(RequestDocument.UserId), query.UserIds.First());
                }
                else
                {
                    builder.In(nameof(RequestDocument.UserId), query.UserIds);
                }
            }
            
            var cursor = await collection.FindAsync(builder.ToBsonDocument());

            return _mapper.Map<ICollection<Domain.Request>>(await cursor.ToListAsync());
        }
    }
}