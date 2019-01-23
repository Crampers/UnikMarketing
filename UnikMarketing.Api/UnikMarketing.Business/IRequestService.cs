using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public interface IRequestService
    {
        Task<ICollection<Request>> GetAll();
        Task<Request> Get(string id);
        Task<Request> Create(Request request);
        Task<Request> Update(Request request);
        Task Delete(Request request);
        Task Delete(string id);
    }
}
