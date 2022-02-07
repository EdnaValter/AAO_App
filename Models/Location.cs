using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string CountryType { get; set; }

        [MaxLength(2)]
        public string CountryCode { get; set; }
        public virtual Department Departments { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
