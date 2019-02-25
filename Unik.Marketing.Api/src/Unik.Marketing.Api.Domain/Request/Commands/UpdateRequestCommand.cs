namespace Unik.Marketing.Api.Domain.Request.Commands
{
    public class UpdateRequestCommand : ICommand<Request>
    {
        public UpdateRequestCommand(Request request)
        {
            Request = request;
        }

        public Request Request { get; set; }
    }
}