namespace Unik.Marketing.Api.Domain.User.Commands
{
    public class UpdateUserCommand : ICommand<User>
    {
        public UpdateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}