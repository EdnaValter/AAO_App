using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Contact
    {
        internal readonly object DepId;

        public int ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Department Departments { get; set; }
    }
}
