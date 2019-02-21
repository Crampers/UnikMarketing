namespace Unik.Marketing.Api.Business.User.Commands
{
    public class CreateUserCommand : ICommand<Domain.User>
    {
        public CreateUserCommand(Domain.User user)
        {
            User = user;
        }

        public Domain.User User { get; set; }
    }
}