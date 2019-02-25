namespace Unik.Marketing.Api.Domain.User.Commands
{
    public class CreateUserCommand : ICommand<User>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}