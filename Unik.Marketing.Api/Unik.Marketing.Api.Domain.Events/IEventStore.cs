﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business.EventStore
{
    public interface IEventStore
    {
        Task Save(Guid id, IEnumerable<IEvent> events);

        Task<IEvent[]> GetHistory(Guid id);
    }
}