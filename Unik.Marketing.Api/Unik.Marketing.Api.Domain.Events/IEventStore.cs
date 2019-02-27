﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Events
{
    public interface IEventStore
    {
        Task Save(Guid id, IEnumerable<IEvent> events);

        Task<IEvent[]> GetHistory(Guid id);
    }
}