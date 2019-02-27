using System;
using Unik.Marketing.Api.Business.EventStore;

namespace Unik.Marketing.Api.Business.Domain.Request.Events
{
    public class RequestCreatedEvent : IEvent
    {
        public RequestCreatedEvent(Guid id, string note, string userId)
        {
            Id = id;
            Note = note;
            UserId = userId;
        }

        public Guid Id { get; set; }

        public string Note { get; set; }

        public string UserId { get; set; }

        public int Version { get; set; }
    }
}