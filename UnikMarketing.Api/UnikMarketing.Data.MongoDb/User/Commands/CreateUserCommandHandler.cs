using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Data.User.Commands;

namespace UnikMarketing.Data.MongoDb.User.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Domain.User>
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<Domain.User> Handle(CreateUserCommand command)
        {
            var document = _mapper.Map<UserDocument>(command.User);
            var collection = _database.GetCollection<UserDocument>(Collections.Users);

            await collection.InsertOneAsync(document);

            return _mapper.Map<Domain.User>(document);
        }
    }
}
