using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unik.Marketing.Api.Data;
using Unik.Marketing.Api.Data.User.Commands;
using Unik.Marketing.Api.Data.User.Queries;
using Unik.Marketing.Api.Domain;

namespace Unik.Marketing.Api.Business
{
    public class UserService : IUserService
    {
        private readonly IDataProcessor _dataProcessor;

        public UserService(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        public Task<ICollection<User>> GetAll()
        {
            return _dataProcessor.Process(new GetUsersQuery());
        }

        public async Task<User> Get(string id)
        {
            var requests = await _dataProcessor.Process(new GetUsersQuery
            {
                Ids = { id }
            });

            return requests.SingleOrDefault();
        }

        public Task<User> Create(User user)
        {
            return _dataProcessor.Process(new CreateUserCommand(user));
        }

        public Task<User> Update(User user)
        {
            return _dataProcessor.Process(new UpdateUserCommand(user));
        }

        public Task Delete(string id)
        {
            return _dataProcessor.Process(new DeleteUserCommand(id));
        }
    }
}