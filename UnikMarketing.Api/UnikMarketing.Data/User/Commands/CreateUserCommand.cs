namespace UnikMarketing.Data.User.Commands
{
    public class CreateUserCommand : ICommand<Domain.User>
    {
        public Domain.User User { get; set; }
    }
}
