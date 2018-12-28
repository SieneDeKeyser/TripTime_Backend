using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Infrastructure.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string additionalContext)
         : base(additionalContext)
        {
        }
    }
}
