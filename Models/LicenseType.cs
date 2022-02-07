using AAO_App.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class LicenseType
    {
        [Key]
        public int LicenseId { get; set; }
        [MaxLength(50)]
        [Required]
        public string LicenseTitle { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
