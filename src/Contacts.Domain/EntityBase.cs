using System;
using System.Collections.Generic;
using MediatR;

namespace Contacts.Domain
{
    public abstract class EntityBase<T>
    {
        public T ID { get; set; }

        public List<IDomainEvent> Events = new List<IDomainEvent>();
    }

    public class DomainEventBase : IDomainEvent
    {
        public DateTime EventDateTime => System.DateTime.UtcNow;
    }

    public interface IDomainEvent:INotification
    {
        public DateTime EventDateTime { get; }
    }
}
