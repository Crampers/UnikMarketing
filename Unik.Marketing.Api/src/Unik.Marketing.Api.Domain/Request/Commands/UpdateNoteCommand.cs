namespace Unik.Marketing.Api.Domain.Request.Commands
{
    public class UpdateNoteCommand : ICommand<Domain.Request.Request>
    {
        public UpdateNoteCommand(string id, string note)
        {
            Id = id;
            Note = note;
        }

        public string Id;

        public string Note { get; set; }
    }
}