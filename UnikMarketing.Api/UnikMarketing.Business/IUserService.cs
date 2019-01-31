using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAll();
        Task<User> Get(string id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Delete(string id);
    }
}