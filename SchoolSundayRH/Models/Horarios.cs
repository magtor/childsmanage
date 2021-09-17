using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Horarios
    {
        public Horarios()
        {
            Horariosdias = new HashSet<Horariosdias>();
            Horariosniveles = new HashSet<Horariosniveles>();
        }

        public uint Horarioid { get; set; }
        public TimeSpan Horaini { get; set; }
        public TimeSpan Horafin { get; set; }
        public int Duracion { get; set; }

        public virtual ICollection<Horariosdias> Horariosdias { get; set; }
        public virtual ICollection<Horariosniveles> Horariosniveles { get; set; }
    }
}
