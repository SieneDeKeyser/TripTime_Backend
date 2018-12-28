using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips.ExtraTripPackages
{
    public class Allinclusive : ExtraPackagesDecorator
    {
        public Allinclusive(Trip basicTrip) : base(basicTrip)
        {
        }

        public override decimal BasicPrice => BasicTrip.BasicPrice + 5000;

    }
}
