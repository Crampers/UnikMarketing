using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnikMarketing.Data;
using UnikMarketing.Data.User.Commands;
using UnikMarketing.Data.User.Queries;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
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

        public Task<User> UpdateCriteria(User user, Criteria criteria)
        {
            user.Criteria = criteria;
            throw new NotImplementedException();
        }

        public Task<User> AddRequest(User user, Request request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            return _dataProcessor.Process(new DeleteUserCommand(id));
        }
    }
}