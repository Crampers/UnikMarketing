using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.User.Commands.Handlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        public Task Handle(DeleteUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}