using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnikMarketing.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<ICollection<User>> GetAll();
        Task<User> Get(string id);
        Task<User> Update(User user);
        Task Delete(User user);
        Task Delete(string id);
    }
}