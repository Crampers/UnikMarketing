using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;
using UnikMarketing.Domain.Repositories;

namespace UnikMarketing.Business
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Task<ICollection<Request>> GetAll()
        {
            return _requestRepository.GetAll();
        }

        public Task<Request> Get(string id)
        {
            return _requestRepository.Get(id);
        }

        public Task<Request> Create(Request request)
        {
            return _requestRepository.Create(request);
        }

        public Task<Request> Update(Request request)
        {
            return _requestRepository.Update(request);
        }

        public Task Delete(Request request)
        {
            return _requestRepository.Delete(request);
        }

        public Task Delete(string id)
        {
            return _requestRepository.Delete(id);
        }
    }
}