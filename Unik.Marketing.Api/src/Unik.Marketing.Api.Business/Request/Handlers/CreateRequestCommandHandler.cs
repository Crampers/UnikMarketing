using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business.Request.Handlers
{
    public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Domain.Request.Request>
    {
        public Task<Domain.Request.Request> Handle(CreateRequestCommand command)
        {
            throw new NotImplementedException();
        }
    }
}