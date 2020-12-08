using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Domain.Aggregates.ContactAggregate
{
    public class Contact: AggregateRoot
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string OrganisationName { get; private set; }

        public string FullName { get; private set; }
        public string Initials { get; private set; }

        public IReadOnlyCollection<Phone> PhoneNumbers => _PhoneNumbers;

        private readonly List<Phone> _PhoneNumbers;

        #region Constructors


        protected Contact():base()
        {
            this._PhoneNumbers = new List<Phone>();
        }

        protected void Update(ContactCreatedEvent @event)
        {
            this.ID = @event.ID;
            this.Version = @event.Version;
            this.FirstName = @event.FirstName;
            this.LastName = @event.LastName;
            this.OrganisationName = @event.OrganisationName;
        }

        private Contact(Guid ID, string firstName, string lastName, string organisation):this()
        {
            var e = new ContactCreatedEvent(ID, this.Version + 1, firstName, lastName, organisation);
            Update(e);
            this.Events.Add(e);
        }

        #endregion

        #region FactoryMethods

        public static Contact CreateWithFirstAndLastNameWithOrganisation(string firstName, string lastName, string organisation)
        {
            return new Contact(Guid.NewGuid(), firstName, lastName, organisation);
        }

        #endregion

        public void AddPhone(Phone phone)
        {
            //ToDo - How do we add the Primary key here? Do we add the entire aggregate? 
            var e = new PhoneNumberCreatedEvent(this.Version + 1,phone);
            Update(e);
            this.Events.Add(e);
        }

        protected void Update(PhoneNumberCreatedEvent @event)
        {
            this.ID = @event.ID;
            this.Version = @event.Version;
            this._PhoneNumbers.Add(@event.Phone);

        }
    }
}
