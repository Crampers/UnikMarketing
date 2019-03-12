using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.User.Commands.Handlers
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Domain.User.User>
    {
        public Task<Domain.User.User> Handle(UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}