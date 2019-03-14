﻿using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Domain.Request.Events
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