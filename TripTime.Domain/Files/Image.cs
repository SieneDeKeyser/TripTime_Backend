using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Trips;

namespace TripTime.Domain.Files
{
   public class Image
    {
        public Guid Id { get; private set; }
        public byte[] ImageInBytes { get; private set; }
        public string Extentsion { get; private set; }
        public DateTime UploadedDate { get; private set; }
        public Guid UserId { get; set; }
        public Guid TripId { get; private set; }
        public Trip Trip { get; private set; }
        //public User User { get; private set; }
    }
}
