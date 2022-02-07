using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Message { get; set; }
        public string DeliveryInfo { get; set; }
        public Contact Contacts { get; set; }
        public Location Locations { get; set; }

        public virtual ICollection<RequestedStatus> RequestedTrips { get; set; }
       
    }
}
