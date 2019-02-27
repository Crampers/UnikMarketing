namespace Unik.Marketing.Api.Business.User
{
    public class UpdateUserCommand : ICommand<Domain.User.User>
    {
        public UpdateUserCommand(Domain.User.User user)
        {
            User = user;
        }

        public Domain.User.User User { get; set; }
    }
}