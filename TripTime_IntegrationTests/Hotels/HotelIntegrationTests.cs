using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.Trips.DTO.Hotels;
using TripTime.Data.Contexts;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using Xunit;
using System.Collections.Generic;

namespace TripTime_IntegrationTests.Hotels
{
   public class HotelIntegrationTests
    {
        private readonly TestServer _server;

        public HotelIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());
        }

        [Fact]
        public async Task GivenNewHotelWithAllPropertiesNeeded_WhenCreatingNewHotel_ThenReturnCreatedResultAndHotelIsInDB()
        {
            using (_server)
            {
                var client = _server.CreateClient();
                var _context = _server.Host.Services.GetService<TripTimeContext>();

                AddressDTO_Create newAddressDto = new AddressDTO_Create()
                {
                    ZipCode = 1820,
                    City = "TestCity",
                    Country = "TestCountry",
                    StreetName = "TestStreetName",
                    StreetNumber = "TestNumberA"
                };

                HotelDTO_Create newHotelDto = new HotelDTO_Create()
                {
                    Address = newAddressDto,
                    Website = "TestWebsite",
                    ContactPerson = "Test contact Person",
                    Name="Test Name"
                };

                var contentHotel = JsonConvert.SerializeObject(newHotelDto);
                var stringContentHotel = new StringContent(contentHotel, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/hotels", stringContentHotel);
                response.EnsureSuccessStatusCode();

                Assert.Equal("Created", response.StatusCode.ToString());
                Assert.NotNull(_context.Hotels.FirstOrDefault(hotel => hotel.Website == newHotelDto.Website));
            }
        }

        [Fact]
        public async Task GivenNewHotelWithNotAllPropertiesNeeded_WhenCreatingNewHotel_ThenReturnBadRequest()
        {
            using (_server)
            {
                var client = _server.CreateClient();
                var _context = _server.Host.Services.GetService<TripTimeContext>();

                AddressDTO_Create newAddressDto = new AddressDTO_Create()
                {
                    ZipCode = 1820,
                    City = "TestCity",
                    Country = "TestCountry",
                    StreetName = "TestStreetName",
                    StreetNumber = "TestNumberA"
                };

                HotelDTO_Create newHotelDto = new HotelDTO_Create()
                {
                    Address = newAddressDto,
                    Website = "",
                    ContactPerson = "Test contact Person"
                };

                var contentHotel = JsonConvert.SerializeObject(newHotelDto);
                var stringContentHotel = new StringContent(contentHotel, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/hotels", stringContentHotel);

                Assert.Equal("BadRequest", response.StatusCode.ToString());
                Assert.Null(_context.Hotels.FirstOrDefault(hotel => hotel.ContactPerson == newHotelDto.ContactPerson));

            }
        }

        [Fact]
        public async Task GivenExistingHotelId_WhenGetHotel_ThenReturnOkWithHotel()
        {
            using (_server)
            {
                var client = _server.CreateClient();
                var _context = _server.Host.Services.GetService<TripTimeContext>();

                AddressDTO_Create newAddressDto = new AddressDTO_Create()
                {
                    ZipCode = 1820,
                    City = "TestCity",
                    Country = "TestCountry",
                    StreetName = "TestStreetName",
                    StreetNumber = "TestNumberA"
                };

                HotelDTO_Create newHotelDto = new HotelDTO_Create()
                {
                    Address = newAddressDto,
                    Website = "TestWebsite",
                    ContactPerson = "Test contact Person",
                    Name = "Test Name"
                };

                var contentHotel = JsonConvert.SerializeObject(newHotelDto);
                var stringContentHotel = new StringContent(contentHotel, Encoding.UTF8, "application/json");
                var responsePost = await client.PostAsync("api/hotels", stringContentHotel);
                var creatingResponseString = await responsePost.Content.ReadAsStringAsync();

                var responseGetHotel = await client.GetAsync($"api/hotels/{creatingResponseString}");
                var responseStringHotel = await responseGetHotel.Content.ReadAsStringAsync();
                var foundHotel = JsonConvert.DeserializeObject<HotelDTO_Return>(responseStringHotel);

                responseGetHotel.EnsureSuccessStatusCode();
                Assert.Equal(newHotelDto.Website, foundHotel.Website);
            }
        }

        [Fact]
        public async Task GivenNonExistingHotelId_WhenGetHotel_ThenReturnNotFound()
        {
            using (_server)
            {
                var client = _server.CreateClient();
                var _context = _server.Host.Services.GetService<TripTimeContext>();

                var responseGetHotel = await client.GetAsync($"api/hotels/{Guid.NewGuid()}");
                var responseStringHotel = await responseGetHotel.Content.ReadAsStringAsync();

                Assert.Equal("NotFound", responseGetHotel.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenList_WhenGetHotels_ThenReturnOkWithList()
        {
            using (_server)
            {
                var client = _server.CreateClient();
                var _context = _server.Host.Services.GetService<TripTimeContext>();

                var responseGetHotel = await client.GetAsync("api/hotels");
                var responseStringHotel = await responseGetHotel.Content.ReadAsStringAsync();
                var listOfHotels = JsonConvert.DeserializeObject<List<HotelDTO_Return>>(responseStringHotel);
                
                Assert.Equal("OK", responseGetHotel.StatusCode.ToString());
                Assert.IsType<List<HotelDTO_Return>>(listOfHotels);
            }
        }

    }
}
