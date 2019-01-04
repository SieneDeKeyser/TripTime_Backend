using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TripTime.Data.Contexts;
using TripTime.Data.Repositories;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using Xunit;

namespace TripTime.Data.Tests.Trips
{
    public class HotelRepositoryTests
    {
        private HotelRepository _repository;

        [Fact]
        public async void GivenNewHotel_WhenSave_ThenHotelInDb()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                _repository = new HotelRepository(context);

                //Given
                Hotel newHotel = Hotel.CreateNewHotel(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "TestName",
                    "TestWebsite",
                    "Test contact Person"
                 );

                //when
                await _repository.Save(newHotel);

                //then
                Assert.NotNull(context.Hotels.FirstOrDefaultAsync(hotel => hotel.Id == newHotel.Id));
            }
        }



        [Fact]
        public async Task GivenHotels_WhenGetHotelById_ThenReturnHotel()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                _repository = new HotelRepository(context);

                //Given
                Address newAddress = Address.CreateNewAddress(
                    1820,
                    "test",
                    "test",
                    "test",
                    "test");
                context.Set<Address>().Add(newAddress);
                Hotel newHotel = Hotel.CreateNewHotel(
                    Guid.NewGuid(),
                    newAddress.Id,
                    "TestName",
                    "TestWebsite",
                    "Test contact Person");
                context.Hotels.Add(newHotel);
                await context.SaveChangesAsync();

                //when
                var foundedHotel = await _repository.GetById(newHotel.Id);

                //then
                Assert.Equal(foundedHotel, newHotel);
            }
        }

        [Fact]
        public async void GivenHotels_WhenGetHotelByNonExistingId_ThenReturnNull()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                _repository = new HotelRepository(context);

                //Given
                Hotel newHotel = Hotel.CreateNewHotel(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "TestName",
                    "TestWebsite",
                    "Test contact Person"
                 );
                await _repository.Save(newHotel);

                //when
                var foundedHotel = await _repository.GetById(Guid.NewGuid());

                //then
                Assert.Null(foundedHotel);
            }
        }


        [Fact]
        public async void GivenHotels_WhenGetAllHotels_ThenReturnListWithhotels()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                _repository = new HotelRepository(context);

                //Given
                Hotel newHotel = Hotel.CreateNewHotel(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "TestName",
                    "TestWebsite",
                    "Test contact Person"
                 );
                await _repository.Save(newHotel);

                //when
                var foundedHotels = await _repository.GetAll();

                //then
                Assert.IsType<List<Hotel>>(foundedHotels);
                Assert.Contains(newHotel, foundedHotels);
            }
        }

        [Fact]
        public async void GivenNoHotels_WhenGetAllHotels_ThenReturnListWithZerohotels()
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                            .Options;

            using (var context = new TripTimeContext(options))
            {
                //Given
                _repository = new HotelRepository(context);

                //when
                var foundedHotels = await _repository.GetAll();

                //then
                Assert.IsType<List<Hotel>>(foundedHotels);
                Assert.Empty(foundedHotels);
            }
        }
    }
}
