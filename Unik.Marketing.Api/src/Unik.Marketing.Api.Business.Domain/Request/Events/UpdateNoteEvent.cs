using Unik.Marketing.Api.Business.EventStore;

namespace Unik.Marketing.Api.Business.Domain.Request.Events
{
    public class UpdateNoteEvent : IEvent
    {
        public UpdateNoteEvent(string note)
        {
            Note = note;
        }

        public string Note { get; set; }

        public int Version { get; set; }
    }
}