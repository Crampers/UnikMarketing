using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.Request.Queries;

namespace UnikMarketing.Data.MongoDb.Request.Queries.Handlers
{
    public class GetRequestByIdQueryHandler : IQueryHandler<GetRequestByIdQuery, Domain.Request>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public GetRequestByIdQueryHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Domain.Request> Handle(GetRequestByIdQuery query)
        {
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);
            var cursor = await collection.FindAsync(Builders<RequestDocument>.Filter.Eq(
                nameof(RequestDocument.Id),
                query.Id
            ));

            return _mapper.Map<Domain.Request>(await cursor.FirstAsync());
        }
    }
}
