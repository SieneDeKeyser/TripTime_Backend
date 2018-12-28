using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips.ExtraTripPackages
{
    public class HalfPension : ExtraPackagesDecorator
    {
        public HalfPension(Trip basicTrip) : base(basicTrip)
        {
        }

        public override decimal BasicPrice => BasicTrip.BasicPrice + 1500;


    }
}
