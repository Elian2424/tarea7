using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prueba.Models
{
    public partial class Provinces
    {
        public Provinces()
        {
            Records = new HashSet<Records>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Records> Records { get; set; }
    }
}
