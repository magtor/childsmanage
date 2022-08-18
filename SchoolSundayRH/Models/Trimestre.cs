using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Trimestre
    {
        public Trimestre()
        {
            Trimestreniv = new HashSet<Trimestreniv>();
        }

        public uint Trimestreid { get; set; }
        public DateTime Fechaini { get; set; }
        public DateTime Fechafin { get; set; }
        public int Numtrimestre { get; set; }

        public virtual ICollection<Trimestreniv> Trimestreniv { get; set; }
    }
}
