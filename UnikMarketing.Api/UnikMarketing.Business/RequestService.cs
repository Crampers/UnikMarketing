using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Data;
using UnikMarketing.Data.Queries.Request;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public class RequestService : IRequestService
    {
        private readonly IQueryProcessor _queryProcessor;

        public RequestService(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<ICollection<Request>> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<Request> Update(Request request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Request request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}