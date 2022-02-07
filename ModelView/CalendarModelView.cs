using AAO_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.ModelView
{
    public class CalendarModelView
    {
        //Fra Trips
        public int TripId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Message { get; set; }
        public string DeliveryInfo { get; set; }

        //Fra RequestedStatus

        public int RequestId { get; set; }
        public int DriverId { get; set; }
        public Status? Status { get; set; }
    }
}
