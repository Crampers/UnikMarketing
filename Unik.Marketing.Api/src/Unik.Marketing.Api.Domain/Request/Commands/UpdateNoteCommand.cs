namespace Unik.Marketing.Api.Domain.Request.Commands
{
    public class UpdateNoteCommand : ICommand<Request>
    {
        public string Id;

        public UpdateNoteCommand(string id, string note)
        {
            Id = id;
            Note = note;
        }

        public string Note { get; set; }
    }
}