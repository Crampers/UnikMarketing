namespace Unik.Marketing.Api.Business.Request.Commands
{
    public class CreateRequestCommand : ICommand<Domain.Request>
    {
        public CreateRequestCommand(Domain.Request request)
        {
            Request = request;
        }

        public Domain.Request Request { get; set; }
    }
}