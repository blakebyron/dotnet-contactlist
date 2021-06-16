using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Contacts.Domain;
using Contacts.Domain.Aggregates.ContactAggregate;

namespace Contacts.IntegrationTests
{
    public class InMemoryEventStore
    {
        private readonly Dictionary<Guid, IEnumerable<Event>> valuePairs = new Dictionary<Guid, IEnumerable<Event>>();

        public InMemoryEventStore()
        {
        }

        internal void Save(Contact contact, string correlationID)
        {
            List<Event> jsonEvents = new List<Event>();
            foreach (var evt in contact.Events.OrderBy(f=> f.Version))
            {
                string asm = String.Format("{0}, {1}", evt.GetType(), "Contacts.Domain");
                Type t = Type.GetType(asm);

                string x = JsonSerializer.Serialize(evt, new JsonSerializerOptions(){  });
                Event e = new Event()
                {
                    CorrelationId = correlationID,
                    AggregateId = contact.ID,
                    AggregateType = contact.GetType().ToString(),
                    EventType = evt.GetType().ToString(),
                    Version = evt.Version,
                    Payload = JsonSerializer.Serialize(evt,evt.GetType())
                };
                jsonEvents.Add(e);
            }
            //
            valuePairs.Add(contact.ID, jsonEvents);
        }

        public Contact Get(Guid ID)
        {
            var serializedEvents = valuePairs[ID];
            List<IDomainEvent> deserializedEvents = new List<IDomainEvent>();

            foreach (var evt in serializedEvents)
            {
                string asm = String.Format("{0}, {1}", evt.EventType, "Contacts.Domain");
                Type t = Type.GetType(asm);
                var e = (IDomainEvent)JsonSerializer.Deserialize(evt.Payload,t);
                deserializedEvents.Add(e);
            }

            var contact = new Contact(ID, deserializedEvents);
            return contact;
        }

        public class Event
        {
            public Guid AggregateId { get; set; }
            public string AggregateType { get; set; }
            public int Version { get; set; }
            public string Payload { get; set; }
            public string CorrelationId { get; set; }
            public string EventType { get; set; }
        }
    }
}
