using System;
using System.Linq;
using Contacts.Domain.Aggregates.ContactAggregate;
using Xunit;

namespace Contacts.UnitTests.Domain
{
    public class ContactAggregateTests
    {
        public ContactAggregateTests()
        {
        }




        [Fact]
        public void CreateWithFirstLastAndOrgansiationName()
        {
            //Arrange
            var builder = new ContactBuilder()
                                .WithDefaultValues();

            //Act
            var contact = builder.Build();

            //Assert
            Assert.NotNull(contact);
            Assert.Single(contact.Events);
            Assert.Equal(1, contact.Version);
            var e = contact.Events.First();
            Assert.IsType<ContactCreatedEvent>(e);
            Assert.Equal(contact.ID, e.ID);

        }

        [Fact]
        public void CreateContactWithSingleValidPhoneNumber()
        {
            //Arrange
            string firstName = "Paul";
            string lastName = "Smith";
            PhoneDescription phoneDescription = new PhoneDescription("Mobile");
            PhoneNumber phoneNumber = new PhoneNumber("01234567890");
            var mobilePhone = new Phone(phoneDescription, phoneNumber);

            //Act
            var contact = Contact.CreateWithFirstAndLastNameWithOrganisation(firstName, lastName, string.Empty);
            contact.AddPhone(mobilePhone);

            //Assert
            Assert.NotNull(contact);
            Assert.Equal(2, contact.Events.Count);
            Assert.Equal(2, contact.Version);
            Assert.IsType<ContactCreatedEvent>(contact.Events.First());
            Assert.IsType<PhoneNumberCreatedEvent>(contact.Events.Last());
            Assert.Equal(1, contact.PhoneNumbers.Count);
            var phone = contact.PhoneNumbers.First();
            Assert.NotNull(phone);
            Assert.Equal(mobilePhone, phone);
        }
    }
}
