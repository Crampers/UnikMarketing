using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public class RequestService : IRequestService
    {
        public Task<ICollection<Request>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Request> Get(string id)
        {
            throw new NotImplementedException();
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