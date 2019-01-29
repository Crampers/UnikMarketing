using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.Request.Commands;

namespace UnikMarketing.Data.MongoDb.Request.Commands.Handlers
{
    public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Domain.Request>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public CreateRequestCommandHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Domain.Request> Handle(CreateRequestCommand command)
        {
            var document = _mapper.Map<RequestDocument>(command.Request);
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);

            await collection.InsertOneAsync(document);

            return _mapper.Map<Domain.Request>(document);
        }
    }
}