using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Infrastructure.Builders
{
   public abstract class Builder<T> where T: new() 
    {
        public T Build() {
            return new T();
        }
    }
}
