using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.Request.Commands;

namespace UnikMarketing.Data.MongoDb.Request.Commands.Handlers
{
    public class UpdateRequestCommandHandler : ICommandHandler<UpdateRequestCommand>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task Handle(UpdateRequestCommand command)
        {
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);

            await collection.FindOneAndUpdateAsync(
                Builders<RequestDocument>.Filter.Eq(nameof(RequestDocument.Id), command.Request.Id),
                Builders<RequestDocument>.Update.Set(nameof(RequestDocument.Note), command.Request.Note)
            );
        }
    }
}
