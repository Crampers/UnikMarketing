using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business.Request.Handlers
{
    public class UpdateRequestCommandHandler : ICommandHandler<UpdateRequestCommand, Domain.Request.Request>
    {
        public Task<Domain.Request.Request> Handle(UpdateRequestCommand command)
        {
            throw new NotImplementedException();
        }
    }
}