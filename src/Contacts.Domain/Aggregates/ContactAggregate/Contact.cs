using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Domain.Aggregates.ContactAggregate
{
    public class Contact:EntityBase<Guid>, IAggregateRoot
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Organisation { get; private set; }

        public string FullName { get; private set; }
        public string Initials { get; private set; }

        public IReadOnlyCollection<Phone> PhoneNumbers => _PhoneNumbers;

        private readonly List<Phone> _PhoneNumbers;

        #region Constructors


        protected Contact()
        {
            this._PhoneNumbers = new List<Phone>();
        }

        private Contact(string firstName, string lastName):this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Events.Add(new ContactCreatedEvent(this));
        }

        private Contact(string firstName, string lastName, string organisation):this(firstName,lastName)
        {
            this.Organisation = organisation;
        }

        #endregion

        #region FactoryMethods

        public static Contact CreateWithFirstAndLastNameWithOrganisation(string firstName, string lastName, string organisation)
        {
            return new Contact(firstName, lastName, organisation);
        }

        #endregion

        public void AddPhone(Phone phone)
        {
            this._PhoneNumbers.Add(phone);
            //ToDo - How do we add the Primary key here? Do we add the entire aggregate? 
            this.Events.Add(new PhoneNumberCreatedEvent(phone.Description.Description, phone.Number.Number));
        }   
    }
}
