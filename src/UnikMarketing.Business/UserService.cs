using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;
using UnikMarketing.Domain.Repositories;

namespace UnikMarketing.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ICollection<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> Get(string id)
        {
            return _userRepository.Get(id);
        }

        public Task<User> Create(User user)
        {
            return _userRepository.Create(user);
        }

        public Task<User> Update(User user)
        {
            return _userRepository.Update(user);
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
            throw new NotImplementedException();
        }
    }
}