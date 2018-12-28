using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.Trips;

namespace TripTime.Service.Trips
{
    public interface ITripService
    {
        Task<string> Create(Trip trip);
        Task<Trip> GetTripById(Guid id);
        Task<List<Trip>> GetAllTrips();
    }
}
