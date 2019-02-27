namespace Unik.Marketing.Api.Business.Request
{
    public class UpdateRequestCommand : ICommand<Domain.Request.Request>
    {
        public UpdateRequestCommand(Domain.Request.Request request)
        {
            Request = request;
        }

        public Domain.Request.Request Request { get; set; }
    }
}