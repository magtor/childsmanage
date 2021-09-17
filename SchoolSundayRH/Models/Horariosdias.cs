using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Horariosdias
    {
        public uint Horariodiaid { get; set; }
        public uint Diaid { get; set; }
        public uint Horarioid { get; set; }

        public virtual Dias Dia { get; set; }
        public virtual Horarios Horario { get; set; }
    }
}
