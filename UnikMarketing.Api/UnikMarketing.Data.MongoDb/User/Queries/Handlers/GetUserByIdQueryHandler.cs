using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.User.Queries;

namespace UnikMarketing.Data.MongoDb.User.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, Domain.User>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Domain.User> Handle(GetUserByIdQuery query)
        {
            var collection = _database.GetCollection<UserDocument>(Collections.Users);
            var cursor = await collection.FindAsync(Builders<UserDocument>.Filter.Eq(
                nameof(UserDocument.Id),
                query.Id
            ));

            return _mapper.Map<Domain.User>(await cursor.FirstOrDefaultAsync());
        }
    }
}