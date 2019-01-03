using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.ContactInformations;
using Xunit;

namespace TripTime.Service.Tests.ContactInformations
{
   public class AddressServiceTests
    {
        private readonly IRepository<Address> _repository;
        private readonly IAddressService _service;

        public AddressServiceTests()
        {
            _repository = Substitute.For<IRepository<Address>>();
            _service = new AddressService(_repository);
        }

        [Fact]
        public void GivenNewAddress_WhenCreatingNewAdress_ThenRepositorySaveIsCalled()
        {
            //Given
            Address newAddress = Address.CreateNewAddress(
                1820,
                "test",
                "test",
                "test",
                "test");

            //when
            _service.Create(newAddress);

            //then
            _repository.Received().Save(newAddress);
        }

        [Fact]
        public async void GivenNonExistingIdAddress_WhenGetAdressById_ThenThrowObjectNotfoundException()
        {
            //Given
            Address fakeAddress = Address.CreateNewAddress(
                1820,
                "test",
                "test",
                "test",
                "test");

            _repository.GetById(fakeAddress.Id).ReturnsNull();

            //Then
            await Assert.ThrowsAsync<ObjectNotFoundException>(() => _service.GetAddressById(fakeAddress.Id));
        }

        [Fact]
        public void GivenIdAdress_WhenGetAdressById_ThenRpositorytGetByIdIsCalles()
        {
            //Given
            Address newAddress = Address.CreateNewAddress(
                1820,
                "test",
                "test",
                "test",
                "test");

            //When
            _service.GetAddressById(newAddress.Id);

            //Then
            _repository.Received().GetById(newAddress.Id);
        }
    }
}
