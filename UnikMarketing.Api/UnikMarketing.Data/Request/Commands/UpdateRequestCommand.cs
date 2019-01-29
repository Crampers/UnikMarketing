namespace UnikMarketing.Data.Request.Commands
{
    public class UpdateRequestCommand : ICommand<Domain.Request>
    {
        public Domain.Request Request { get; set; }
    }
}
