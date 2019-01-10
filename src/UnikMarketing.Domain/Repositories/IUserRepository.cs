using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnikMarketing.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<ICollection<User>> GetAll();
        Task<User> Get(int id);
        Task<User> Update(User user);
        Task Delete(User user);
        Task Delete(int id);
    }
}
