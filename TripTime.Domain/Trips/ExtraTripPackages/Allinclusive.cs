using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips.ExtraTripPackages
{
    public class Allinclusive : ExtraPackagesDecorator
    {
        public override decimal BasicPrice => BasicTrip.BasicPrice + 5000;
        public Allinclusive(Trip basicTrip) : base(basicTrip)
        {
        }
    }
}
