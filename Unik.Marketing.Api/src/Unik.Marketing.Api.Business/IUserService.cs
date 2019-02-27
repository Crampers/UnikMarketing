using System.Collections.Generic;
using System.Threading.Tasks;
using Unik.Marketing.Api.Domain;

namespace Unik.Marketing.Api.Business
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