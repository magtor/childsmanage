using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Dias
    {
        public Dias()
        {
            Horariosdias = new HashSet<Horariosdias>();
        }

        public uint Diaid { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Horariosdias> Horariosdias { get; set; }
    }
}
