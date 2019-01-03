using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Repositories;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.Service.Trips
{
    public class TripService : ITripService
    {
        private readonly IRepository<Trip> _repository;

        public TripService(IRepository<Trip> repository)
        {
            _repository = repository;
        }

        public async Task<string> Create(Trip trip)
        {
            await _repository.Save(trip);
            return trip.Id.ToString();
        }

        public async Task<List<Trip>> GetAllTrips()
        {
            return await _repository.GetAll();
        }

        public async Task<Trip> GetTripById(Guid id)
        {
            var trip = await _repository.GetById(id);
            if (trip == null)
            {
                throw new ObjectNotFoundException("Searching Trip by id", "Trip", id);
            }
            return trip;
        }
    }
}
