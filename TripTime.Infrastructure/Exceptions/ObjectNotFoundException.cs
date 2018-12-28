using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Infrastructure.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string additionalContext, string className, Guid id)
        : base("During " + additionalContext + ", the following entity was not found: " + className + " with id = " + id.ToString("N"))
        {
        }
    }
}
