using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips.ExtraTripPackages
{
    public class HalfPension : ExtraPackagesDecorator
    {
        public override decimal BasicPrice => BasicTrip.BasicPrice + 1500;

        public HalfPension(Trip basicTrip) : base(basicTrip)
        {
        }
    }
}
