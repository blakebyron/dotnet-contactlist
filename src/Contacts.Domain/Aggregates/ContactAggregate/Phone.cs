using System;
using System.Collections.Generic;

namespace Contacts.Domain.Aggregates.ContactAggregate
{
    public class Phone : ValueObject
    {

        public PhoneDescription Description { get; private set; }
        public PhoneNumber Number { get; private set; }

        public Phone(PhoneDescription description, PhoneNumber number)
        {
            this.Description = description;
            this.Number = number;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Description;
            yield return Number;

        }
    }

    public class PhoneDescription: ValueObject
    {
        public string Description { get; private set; }

        public PhoneDescription(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Description;

        }
    }

    public class PhoneNumber: ValueObject
    {
        public string Number { get; private set; }
        public PhoneNumber(string number)
        {
            Number = number ?? throw new ArgumentNullException(nameof(number));
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}
