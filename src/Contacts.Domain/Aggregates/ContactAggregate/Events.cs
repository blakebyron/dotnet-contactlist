using System;
using MediatR;

namespace Contacts.Domain.Aggregates.ContactAggregate
{
    public class ContactCreatedEvent:DomainEvent
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganisationName { get; set; }

        //public DateTime EventDateTime { get; set; }

        //public Guid ID { get; set; }

        //public int Version { get; set; }

        public ContactCreatedEvent(Guid ID, Int32 version, string firstName, string lastName, string organisationName)
        {
            this.ID = ID;
            this.Version = version;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OrganisationName = organisationName;
        }
    }

    public class PhoneNumberCreatedEvent : DomainEvent
    {
        public Phone Phone { get; set; }

        public PhoneNumberCreatedEvent(Int32 version, Phone phone)
        {
            this.Version = version;
            this.Phone = phone;
        }
    }
}
