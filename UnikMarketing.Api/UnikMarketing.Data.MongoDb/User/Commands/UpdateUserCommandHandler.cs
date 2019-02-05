using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.User.Commands;

namespace UnikMarketing.Data.MongoDb.User.Commands
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Domain.User>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Domain.User> Handle(UpdateUserCommand command)
        {
            var document = _mapper.Map<UserDocument>(command.User);
            var collection = _database.GetCollection<UserDocument>(Collections.Users);
            var updatedDocument = await collection.FindOneAndUpdateAsync(
                Builders<UserDocument>.Filter.Eq(nameof(UserDocument.Id), document.Id),
                Builders<UserDocument>.Update
                    .Set(nameof(UserDocument.Address), document.Address)
                    .Set(nameof(UserDocument.Criteria), document.Criteria)
                    .Set(nameof(UserDocument.Email), document.Email)
                    .Set(nameof(UserDocument.Name), document.Name)
                    .Set(nameof(UserDocument.Password), document.Password)
                    .Set(nameof(UserDocument.ZipCode), document.ZipCode)
            );

            return _mapper.Map<Domain.User>(updatedDocument);
        }
    }
}