using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class Department
    {

        [Key]
        public int DepId { get; set; }
        public string DepName { get; set; }
        public string Addresse { get; set; }
        public string Country { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
