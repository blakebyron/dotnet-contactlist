using Contacts.Domain.Aggregates.ContactAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.UnitTests
{
    public class ContactBuilder
    {
        private Contact _contact = null;

        public ContactBuilder WithDefaultValues()
        {
            _contact = Contact.CreateWithFirstAndLastNameWithOrganisation("Paul", "Smith", "The Best Company LTD");

            return this;
        }

        public Contact Build() => _contact;
    }
}
