namespace Unik.Marketing.Api.Domain.Request.Commands
{
    public class CreateRequestCommand : ICommand<Domain.Request.Request>
    {
        public CreateRequestCommand(string note, string userId)
        {
            Note = note;
            UserId = userId;
        }

        public string Note { get; set; }

        public string UserId { get; set; }
    }
}