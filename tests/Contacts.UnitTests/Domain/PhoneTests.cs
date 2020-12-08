using Contacts.Domain.Aggregates.ContactAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Contacts.UnitTests.Domain
{
    public class PhoneTests
    {
        [Fact]
        public void Create_Null_PhoneNumber()
        {
            //Arrange
            string phoneNumber = null;
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PhoneNumber(phoneNumber));
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

        //[Fact]
        //public void Create_Invalid_PhoneNumber()
        //{
        //    //Arrange
        //    string phoneNumber = "ASDASD";
        //    //Act & Assert
        //    Assert.Throws<ArgumentException>(() => new PhoneNumber(phoneNumber));
        //}

        [Fact]
        public void Create_Null_PhoneDescription()
        {
            //Arrange
            string phoneNumber = null;
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PhoneDescription(phoneNumber));
        }

        [Fact]
        public void Create_Valid_PhoneDescription()
        {
            //Arrange
            string desc = "Mobile";
            //Act
            var sut = new PhoneDescription(desc);
            //Assert
            Assert.NotNull(sut);
        }



    }
}
