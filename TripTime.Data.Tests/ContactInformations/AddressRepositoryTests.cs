using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Data.Contexts;
using TripTime.Data.Repositories;
using TripTime.Domain.ContactInformation;
using Xunit;

namespace TripTime.Data.Tests.ContactInformations
{
    public class AddressRepositoryTests
    {
        private AddressRepository _repository;

        [Fact]
        public async void GivenNewAddress_WhenSave_ThenAddressInDb()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                _repository = new AddressRepository(context);

                //Given
                Address newAddress = Address.CreateNewAddress(
                    1820,
                    "test",
                    "test",
                    "test",
                    "test");

                //when
                await _repository.Save(newAddress);

                //then
                Assert.Contains(newAddress, context.Set<Address>());
            }
        }

        [Fact]
        public async void GivenAddress_WhenGetAddressByNonExistingId_ThenReturnNull()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                _repository = new AddressRepository(context);

                //Given
                Address newAddress = Address.CreateNewAddress(
                    1820,
                    "test",
                    "test",
                    "test",
                    "test");

                await _repository.Save(newAddress);

                //when
                var foundedHotel = await _repository.GetById(Guid.NewGuid());

                //then
                Assert.Null(foundedHotel);
            }
        }


    }
}
