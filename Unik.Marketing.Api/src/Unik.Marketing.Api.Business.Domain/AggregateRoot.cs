using System;
using System.Collections.Generic;
using System.Reflection;
using Unik.Marketing.Api.Business.EventStore;

namespace Unik.Marketing.Api.Business.Domain
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();
        
        public abstract Guid Id { get; }

        public int Version { get; private set; }

        public IEvent[] GetUncommittedChanges()
        {
            return _changes.ToArray();
        }

        public IEvent[] FlushUncommittedChanges()
        {
            lock (_changes)
            {
                var changes = _changes.ToArray();
                Version += changes.Length;

                _changes.Clear();

                return changes;
            }
        }

        public void LoadsFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var @event in history)
            {
                ApplyChange(@event, false);
            }
        }

        protected void ApplyChange(IEvent @event)
        {
            ApplyChange(@event, true);
        }
        
        private void ApplyChange(IEvent @event, bool isNew)
        {
            GetType()
                .GetMethod(
                    "Apply",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    Type.DefaultBinder,
                    CallingConventions.HasThis,
                    new[] { @event.GetType() },
                    new ParameterModifier[0]
                )
                ?.Invoke(
                    this, 
                    new object[] {@event}
                );

            Version++;

            if (isNew)
            {
                _changes.Add(@event);
            }
        }
    }
}