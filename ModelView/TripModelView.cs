using AAO_App.Models;
using System;
using System.Collections.Generic;

namespace AAO_App.ModelView
{
    public class MyTrip
    {

        //Fra Trips
        public int TripId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Message { get; set; }
        public string DeliveryInfo { get; set; }

        //Fra Contact
        public int ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Fra Departments
        public int DepId { get; set; }
        public string DepName { get; set; }
        public string Country { get; set; }

        //Fra Location
        public int LocationId { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

        //Fra RequestedStatus

        public int RequestId { get; set; }
        public int DriverId { get; set; }
        public Status? Status { get; set; }
    }
}
