using System;
namespace Contacts.Domain.Aggregates.ContactAggregate
{
    public class Phone
    {

        public PhoneDescription Description { get; private set; }
        public PhoneNumber Number { get; private set; }

        public Phone(PhoneDescription description, PhoneNumber number)
        {
            this.Description = description;
            this.Number = number;
        }

    }

    public class PhoneDescription
    {
        public string Description { get; private set; }

        public PhoneDescription(string description)
        {
            this.Description = description;
        }
    }

    public class PhoneNumber
    {
        public string Number { get; private set; }
        public PhoneNumber(string number)
        {
            Number = number ?? throw new ArgumentNullException(nameof(number));
        }
    }
}
