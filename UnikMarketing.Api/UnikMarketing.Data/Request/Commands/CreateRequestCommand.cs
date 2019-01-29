namespace UnikMarketing.Data.MongoDb.Request.Commands.Handlers
{
    public class CreateRequestCommand : ICommand<Domain.Request>
    {
        public Domain.Request Request { get; set; }
    }
}