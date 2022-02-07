//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AAO_App.Models
//{
//    public class DriversLicenseRecord
//    {
//        [Key]
//        public int LicenseTypesId { get; set; }
//        public int DriverId { get; set; }
//        public DateTime ExpDate { get; set; }
//        [NotMapped]
//        public IFormFile LicenseImage { get; set; }
//        public virtual ICollection<Driver> Drivers { get; set; }
//    }
//}
