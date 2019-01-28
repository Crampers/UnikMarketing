namespace UnikMarketing.Data.Request.Commands
{
    public class UpdateRequestCommand : ICommand
    {
        public Domain.Request Request { get; set; }
    }
}
