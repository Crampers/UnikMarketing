namespace UnikMarketing.Data.User.Commands
{
    public class UpdateUserCommand : ICommand<Domain.User>
    {
        public Domain.User User { get; set; }
    }
}
