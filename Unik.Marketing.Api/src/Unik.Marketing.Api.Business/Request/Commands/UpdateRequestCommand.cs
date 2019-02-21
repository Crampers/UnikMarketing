namespace Unik.Marketing.Api.Business.Request.Commands
{
    public class UpdateRequestCommand : ICommand<Domain.Request>
    {
        public UpdateRequestCommand(Domain.Request request)
        {
            Request = request;
        }

        public Domain.Request Request { get; set; }
    }
}