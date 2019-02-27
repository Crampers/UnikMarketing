namespace Unik.Marketing.Api.Business.Request
{
    public class CreateRequestCommand : ICommand<Domain.Request.Request>
    {
        public CreateRequestCommand(Domain.Request.Request request)
        {
            Request = request;
        }

        public Domain.Request.Request Request { get; set; }
    }
}