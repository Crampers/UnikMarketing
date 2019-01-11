using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnikMarketing.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task<Request> Create(Request user);
        Task<ICollection<Request>> GetAll();
        Task<Request> Get(int id);
        Task<Request> Update(Request user);
        Task Delete(Request user);
        Task Delete(int id);
    }
}
