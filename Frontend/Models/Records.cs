using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prueba.Models
{
    public partial class Records
    {
        public int Id { get; set; }
        public int Citizen { get; set; }
        public int Vaccine { get; set; }
        public int Province { get; set; }
        public DateTime? FirstVacDate { get; set; }
        public DateTime? LastVacDate { get; set; }

        public virtual Citizens CitizenNavigation { get; set; }
        public virtual Provinces ProvinceNavigation { get; set; }
        public virtual Vaccines VaccineNavigation { get; set; }
    }
}
