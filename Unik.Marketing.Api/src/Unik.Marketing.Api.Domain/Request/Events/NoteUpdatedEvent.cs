using System;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Domain.Request.Events
{
    public class NoteUpdatedEvent : IEvent
    {
        public NoteUpdatedEvent(Guid requestId, string note)
        {
            RequestId = requestId;
            Note = note;
        }

        public Guid RequestId { get; set; }

        public string Note { get; set; }

        public int Version { get; set; }
    }
}