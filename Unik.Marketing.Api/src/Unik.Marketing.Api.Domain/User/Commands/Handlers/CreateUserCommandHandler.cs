using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.User.Commands.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Domain.User.User>
    {
        public Task<Domain.User.User> Handle(CreateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}