using System;
using MediatR;

namespace Contacts.Domain.Aggregates.ContactAggregate
{
    public class PhoneNumberCreatedEvent : DomainEventBase
    {
        public string PhoneDescription { get; private set; }
        public string PhoneNumber { get; private set; }

        public PhoneNumberCreatedEvent(string phoneDescription, string phoneNumber)
        {
            this.PhoneDescription = phoneDescription;
            this.PhoneNumber = phoneNumber;
        }
    }

    public class ContactCreatedEvent:DomainEventBase
    {
        //Todo Add fields which are populated as part of the create
        public Contact Contact { get; set; }

        public ContactCreatedEvent(Contact contact)
        {
            this.Contact = contact;
        }
    }
}
