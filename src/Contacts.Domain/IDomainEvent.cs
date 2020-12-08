using System;
using System.Collections.Generic;
using MediatR;

namespace Contacts.Domain
{
    public interface IDomainEvent : INotification
    {
        public DateTime EventDateTime { get; }
        public Guid ID { get; }
        public Int32 Version { get; }
    }

    public class DomainEvent : IDomainEvent
    {
        public DateTime EventDateTime => System.DateTime.UtcNow;
        public Guid ID { get; set; }
        public Int32 Version { get; set; }
    }


}
