using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Request.Commands.Handlers
{
    public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Request>
    {
        public Task<Request> Handle(CreateRequestCommand command)
        {
            throw new NotImplementedException();
        }
    }
}