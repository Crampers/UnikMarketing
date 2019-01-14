using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public class UserService : IUserService
    {
        public async Task<ICollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(User user)
        {
            throw new NotImplementedException();
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

        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
