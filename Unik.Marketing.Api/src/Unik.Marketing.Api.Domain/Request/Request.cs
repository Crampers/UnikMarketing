using System;
using Unik.Marketing.Api.Domain.Request.Events;

namespace Unik.Marketing.Api.Domain.Request
{
    public class Request : AggregateRoot
    {
        private Guid _id;

        public Request()
        {
            
        }

        public Request(string note, string userId)
        {
            ApplyChange(new RequestCreatedEvent(Guid.NewGuid(), note, userId));
        }

        public void UpdateNote(string note)
        {
            ApplyChange(new UpdateNoteEvent(note));
        }

        public string Note { get; private set; }

        public string UserId { get; private set; }

        public override Guid Id => _id;

        private void Apply(RequestCreatedEvent @event)
        {
            _id = @event.Id;
            Note = @event.Note;
            UserId = @event.UserId;
        }

        private void Apply(UpdateNoteEvent @event)
        {
            Note = @event.Note;
        }
    }
}