using System;
using Contacts.Domain.Aggregates.ContactAggregate;
using Xunit;

namespace Contacts.IntegrationTests
{
    public class InMemoryStoreTests
    {


        [Fact]
        public void CreateContactStoreAndReloadUsingEvents()
        {
            string firstName = "Paul";
            string lastName = "Smith";
            PhoneDescription phoneDescription = new PhoneDescription("Mobile");
            PhoneNumber phoneNumber = new PhoneNumber("01234567890");
            var mobilePhone = new Phone(phoneDescription, phoneNumber);

            //Act
            var contact = Contact.CreateWithFirstAndLastNameWithOrganisation(firstName, lastName, string.Empty);
            contact.AddPhone(mobilePhone);


            string correlationID = Guid.NewGuid().ToString();
            var eventStore = new InMemoryEventStore();
            eventStore.Save(contact,correlationID);



            var resultContact = eventStore.Get(contact.ID);


            Assert.NotNull(resultContact);
            Assert.Equal(contact.FirstName, resultContact.FirstName);
            Assert.Equal(contact.LastName, resultContact.LastName);
            Assert.Equal(contact.OrganisationName, resultContact.OrganisationName);


        }
    }

}
