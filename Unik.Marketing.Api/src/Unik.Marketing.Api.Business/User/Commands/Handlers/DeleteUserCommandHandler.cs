using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using Unik.Marketing.Api.Data.MongoDb;
using Unik.Marketing.Api.Data.MongoDb.Documents;

namespace Unik.Marketing.Api.Business.User.Commands.Handlers
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