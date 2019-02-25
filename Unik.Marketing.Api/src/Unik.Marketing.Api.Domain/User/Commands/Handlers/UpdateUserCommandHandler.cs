using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.User.Commands.Handlers
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, User>
    {
        public Task<User> Handle(UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}