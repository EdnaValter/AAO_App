using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public enum Status
    {
        Available, Requested, Denied, Approved, Cancel
    }
    public class RequestedStatus
    {
        [Key]
        public int RequestId { get; set; }
        public int TripId { get; set; }
        public int DriverId { get; set; }
        public Status? Status { get; set; }

        public virtual Trip Trips { get; set; }
        public virtual Driver Drivers { get; set; }
    }
}
