using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.ModelView
{
    public class ProfileModelView
    {
        //Fra Driver
        public int DriverId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Addresse { get; set; }

        public string Phone { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate:")]
        public DateTime DoB { get; set; }

        [MaxLength(6)]
        [Required]
        public string Password { get; set; }
        public IFormFile ProfileImage { get; set; }
        [Required]
        public bool License { get; set; }

        //Fra License
        public int LicenseId { get; set; }
        public string  LicenseTitle { get; set; }
        public DateTime ExpDate { get; set; }
        public IFormFile LicenseImg{ get; set; }

        //Fra LOcation 
        public int LocationId { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }
}
