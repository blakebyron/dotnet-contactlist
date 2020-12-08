using System;
using System.Collections.Generic;

namespace Contacts.Domain
{
    public interface IAggregateRoot
    {
    }

    public abstract class AggregateRoot: IAggregateRoot
    {
        public Guid ID { get; protected set; }

        public int Version { get; protected set; }

        public List<IDomainEvent> Events = new List<IDomainEvent>();

    }
}
