using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Data;
using UnikMarketing.Data.Queries.Request;
using UnikMarketing.Domain;
using UnikMarketing.Domain.Repositories;

namespace UnikMarketing.Business
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IQueryProcessor _queryProcessor;

        public RequestService(IRequestRepository requestRepository, IQueryProcessor queryProcessor)
        {
            _requestRepository = requestRepository;
            _queryProcessor = queryProcessor;
        }

        public Task<ICollection<Request>> GetAll()
        {
            return _requestRepository.GetAll();
        }

        public Task<Request> Get(string id)
        {
            return _queryProcessor.Process(new GetRequestByIdQuery()
            {
                Id = id
            });
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