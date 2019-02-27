namespace Unik.Marketing.Api.Business.User
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