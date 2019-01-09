using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;
namespace UnikMarketing.Business
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAll();
        Task<User> Get(int id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> UpdateCriteria(User user, Criteria criteria);
        Task<User> AddRequest(User user, Request request);
        Task Delete(int id);
    }
}
