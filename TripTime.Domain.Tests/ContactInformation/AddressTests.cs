using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.Exceptions;
using Xunit;

namespace TripTime.Domain.Tests.ContactInformation
{
   public class AddressTests
    {
        [Fact]
        public void GivenAnAddressWithEmptyZipCode_WhenCreatingNewAddress_ThenThrowObjectNotValidException()
        {
            //Given
            var zipcode = 0;
            var country = "Test Country";
            var city = "Test city";
            var streetName = "Test streetame";
            var streetNumber = "Test streetNumber";

            //When
            Action act = () => Address.CreateNewAddress(zipcode, city, country, streetName, streetNumber);

            //then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenAnAddressWithEmptyCountry_WhenCreatingNewAddress_ThenThrowObjectNotValidException()
        {
            //Given
            var zipcode = 1820;
            var country = "";
            var city = "Test city";
            var streetName = "Test streetame";
            var streetNumber = "Test streetNumber";

            //When
            Action act = () => Address.CreateNewAddress(zipcode, city, country, streetName, streetNumber);

            //then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenAnAddressWithEmptyCity_WhenCreatingNewAddress_ThenThrowObjectNotValidException()
        {
            //Given
            var zipcode = 1820;
            var country = "Test Country";
            var city = "";
            var streetName = "Test streetame";
            var streetNumber = "Test streetNumber";

            //When
            Action act = () => Address.CreateNewAddress(zipcode, city, country, streetName, streetNumber);

            //then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenAnAddressWithEmptyStreetName_WhenCreatingNewAddress_ThenThrowObjectNotValidException()
        {
            //Given
            var zipcode = 1820;
            var country = "Test Country";
            var city = "Test city";
            var streetName = "";
            var streetNumber = "Test streetNumber";

            //When
            Action act = () => Address.CreateNewAddress(zipcode, city, country, streetName, streetNumber);

            //then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenAnAddressWithEmptyStreetnumber_WhenCreatingNewAddress_ThenThrowObjectNotValidException()
        {
            //Given
            var zipcode = 0;
            var country = "Test Country";
            var city = "Test city";
            var streetName = "Test streetame";
            var streetNumber = "";

            //When
            Action act = () => Address.CreateNewAddress(zipcode, city, country, streetName, streetNumber);

            //then
            Assert.Throws<ObjectNotValidException>(act);
        }
    
        [Fact]
        public void GivenAnAddressWithallNeededProperties_WhenCreatingNewAddress_ThenreturnNewAddressWithGuidId()
        {
            //Given
            var zipcode = 1820;
            var country = "Test Country";
            var city = "Test city";
            var streetName = "Test streetame";
            var streetNumber = "Test StreetNumber";

            //When
            var newAddress = Address.CreateNewAddress(zipcode, city, country, streetName, streetNumber);

            //then
            Assert.NotEqual(Guid.Empty, newAddress.Id);
            Assert.IsType<Address>(newAddress);
        }
    }
}
