using System.Collections.Generic;
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

            if (query.UserId != null)
            {
                builder.Eq(nameof(RequestDocument.UserId), query.UserId);
            }


            var cursor = await collection.FindAsync(builder.ToBsonDocument());

            return _mapper.Map<ICollection<Domain.Request>>(await cursor.ToListAsync());
        }
    }
}