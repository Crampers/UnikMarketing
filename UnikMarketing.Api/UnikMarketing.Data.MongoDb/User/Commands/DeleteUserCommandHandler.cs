using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.User.Commands;

namespace UnikMarketing.Data.MongoDb.User.Commands
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task Handle(DeleteUserCommand command)
        {
            var collection = _database.GetCollection<UserDocument>(Collections.Users);

            await collection.FindOneAndDeleteAsync(Builders<UserDocument>.Filter.Eq(
                nameof(UserDocument.Id),
                command.Id
            ));
        }
    }
}
