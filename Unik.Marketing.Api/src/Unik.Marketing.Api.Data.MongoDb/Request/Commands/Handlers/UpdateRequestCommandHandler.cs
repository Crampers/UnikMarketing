using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using Unik.Marketing.Api.Data.MongoDb.Documents;
using Unik.Marketing.Api.Data.Request.Commands;

namespace Unik.Marketing.Api.Data.MongoDb.Request.Commands.Handlers
{
    public class UpdateRequestCommandHandler : ICommandHandler<UpdateRequestCommand, Domain.Request>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Domain.Request> Handle(UpdateRequestCommand command)
        {
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);

            return _mapper.Map<Domain.Request>(await collection.FindOneAndUpdateAsync<RequestDocument>(
                Builders<RequestDocument>.Filter.Eq(nameof(RequestDocument.Id), command.Request.Id),
                Builders<RequestDocument>.Update.Set(nameof(RequestDocument.Note), command.Request.Note)
            ));
        }
    }
}