using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Infrastructure.Exceptions
{
    public class ObjectNotValidException: Exception
    {
        public ObjectNotValidException(string additionalContext, object entity)
         : base("During " + additionalContext + ", the following entity was found to be invalid: " + entity)
        {
        }
    }
}
