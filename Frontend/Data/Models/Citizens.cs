using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prueba.Data.Models
{
    public partial class Citizens
    {
        public Citizens()
        {
            Records = new HashSet<Records>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdNumber { get; set; }

        public virtual ICollection<Records> Records { get; set; }
    }
}
