namespace Unik.Marketing.Api.Domain.User.Commands
{
    public class CreateUserCommand : ICommand<Domain.User.User>
    {
        public CreateUserCommand(Domain.User.User user)
        {
            User = user;
        }

        public Domain.User.User User { get; set; }
    }
}