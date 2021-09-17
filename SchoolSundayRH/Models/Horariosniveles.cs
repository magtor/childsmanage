using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Horariosniveles
    {
        public uint Horarionivelid { get; set; }
        public uint Horarioid { get; set; }
        public uint Nivelid { get; set; }
        public uint Periodoid { get; set; }

        public virtual Horarios Horario { get; set; }
        public virtual Niveles Nivel { get; set; }
        public virtual Periodos Periodo { get; set; }
    }
}
