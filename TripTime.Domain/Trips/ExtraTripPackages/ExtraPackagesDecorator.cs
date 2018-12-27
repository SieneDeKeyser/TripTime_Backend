using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips.ExtraTripPackages
{
   public abstract class ExtraPackagesDecorator: Trip
    {
        public Trip BasicTrip { get;}
        protected ExtraPackagesDecorator(Trip basicTrip)
        {
            BasicTrip = basicTrip;
        }
    }
}
