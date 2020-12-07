using System;
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
        public void Create_Valid_PhoneNumber()
        {
            //Arrange
            string phoneNumber = "07123456789";
            //Act
            var sut = new PhoneNumber(phoneNumber);
            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void Create_Null_PhoneNumber()
        {
            //Arrange
            string phoneNumber = null;
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PhoneNumber(phoneNumber));
        }

        //[Fact]
        //public void Create_Invalid_PhoneNumber()
        //{
        //    //Arrange
        //    string phoneNumber = "ASDASD";
        //    //Act & Assert
        //    Assert.Throws<ArgumentException>(() => new PhoneNumber(phoneNumber));
        //}

        [Fact]
        public void CreateWithFirstLastAndOrgansiationName()
        {
            //Arrange
            string firstName = "Paul";
            string lastName = "Smith";

            //Act
            var contact = Contact.CreateWithFirstAndLastNameWithOrganisation(firstName, lastName, string.Empty);

            //Assert
            Assert.NotNull(contact);
            Assert.Single(contact.Events);
            Assert.True(contact.Events.Exists(f => f.GetType() == typeof(ContactCreatedEvent)));

        }

        [Fact]
        public void CreateContactWithSingleValidPhoneNumber()
        {
            //Arrange
            string firstName = "Paul";
            string lastName = "Smith";
            PhoneDescription phoneDescription = new PhoneDescription("Mobile");
            PhoneNumber phoneNumber = new PhoneNumber("01234567890");

            //Act
            var contact = Contact.CreateWithFirstAndLastNameWithOrganisation(firstName, lastName, string.Empty);
            contact.AddPhone(new Phone(phoneDescription, phoneNumber));

            //Assert
            Assert.NotNull(contact);
            Assert.Equal(2, contact.Events.Count);
            Assert.True(contact.Events.Exists(f => f.GetType() == typeof(ContactCreatedEvent)));
        }
    }
}
