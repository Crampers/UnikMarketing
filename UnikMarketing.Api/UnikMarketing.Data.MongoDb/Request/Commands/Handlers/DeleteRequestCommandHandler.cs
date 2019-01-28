using System.Threading.Tasks;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.Request.Commands;

namespace UnikMarketing.Data.MongoDb.Request.Commands.Handlers
{
    public class DeleteRequestCommandHandler : ICommandHandler<DeleteRequestCommand>
    {
        private readonly IMongoDatabase _database;

        public DeleteRequestCommandHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task Handle(DeleteRequestCommand command)
        {
            await _database
                .GetCollection<RequestDocument>(Collections.Requests)
                .FindOneAndDeleteAsync(Builders<RequestDocument>.Filter.Eq(
                    nameof(RequestDocument.Id),
                    command.Id
                ));
        }
    }
}
