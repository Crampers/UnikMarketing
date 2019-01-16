﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnikMarketing.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task<Request> Create(Request request);
        Task<ICollection<Request>> GetAll();
        Task<Request> Get(string id);
        Task<Request> Update(Request request);
        Task Delete(Request request);
        Task Delete(string id);
    }
}