using App.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAO_App.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [MaxLength(255)]
        [Required]
        public string Firstname { get; set; }
        [MaxLength(255)]
        [Required]
        public string Lastname { get; set; }
        [MaxLength(255)]
        [Required]
        public string Addresse { get; set; }

        [MaxLength(12)]
        [Required]
        public string Phone { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate:")]
        public DateTime DoB { get; set; }

        [MaxLength(6)]
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
        [Required]
        public bool License { get; set; }
 

        public virtual Location Locations { get; set; }
        public virtual ICollection<RequestedStatus> RequestedTrips { get; set; }
        public virtual ICollection<LicenseType> LicenseTypes { get; set; }
    }
}
