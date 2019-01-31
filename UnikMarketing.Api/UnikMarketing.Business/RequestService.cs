using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnikMarketing.Data;
using UnikMarketing.Data.Request.Commands;
using UnikMarketing.Data.Request.Queries;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public class RequestService : IRequestService
    {
        private readonly IDataProcessor _dataProcessor;

        public RequestService(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        public Task<ICollection<Request>> GetAll()
        {
            return _dataProcessor.Process(new GetRequestsQuery());
        }

        public async Task<Request> Get(string id)
        {
            var requests = await _dataProcessor.Process(new GetRequestsQuery
            {
                Ids = { id }
            });

            return requests.SingleOrDefault();
        }

        public Task<Request> Create(Request request)
        {
            return _dataProcessor.Process(new CreateRequestCommand(request));
        }

        public Task<Request> Update(Request request)
        {
            return _dataProcessor.Process(new UpdateRequestCommand(request));
        }

        public Task Delete(Request request)
        {
            return Delete(request.Id);
        }

        public Task Delete(string id)
        {
            return _dataProcessor.Process(new DeleteRequestCommand(id));
        }

        public Task<ICollection<Request>> GetByUser(string id)
        {
            return _dataProcessor.Process(new GetRequestsQuery
            {
                UserIds = { id }
            });
        }
    }
}