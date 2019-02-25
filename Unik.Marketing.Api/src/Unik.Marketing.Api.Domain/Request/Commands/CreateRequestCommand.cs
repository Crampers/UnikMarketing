namespace Unik.Marketing.Api.Domain.Request.Commands
{
    public class CreateRequestCommand : ICommand<Request>
    {
        public CreateRequestCommand(Request request)
        {
            Request = request;
        }

        public Request Request { get; set; }
    }
}