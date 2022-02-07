using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public enum Types
    {
        Ledig, Optaget
    }
    public class Calendar
    {
            [Key]
            public int CalendarId { get; set; }

            //Foreign key
            public Driver Drivers { get; set; }

            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime Start { get; set; }

            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime End { get; set; }

        public Types? Types{ get; set; }
        public RequestedStatus RequestedStatus { get; set; }
        
    }
}
