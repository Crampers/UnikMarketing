using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.User.Commands.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, User>
    {
        public Task<User> Handle(CreateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}