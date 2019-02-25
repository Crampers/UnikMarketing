using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Request.Commands.Handlers
{
    public class UpdateRequestCommandHandler : ICommandHandler<UpdateRequestCommand, Request>
    {
        public Task<Request> Handle(UpdateRequestCommand command)
        {
            throw new NotImplementedException();
        }
    }
}