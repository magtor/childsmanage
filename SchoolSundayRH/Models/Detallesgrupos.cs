using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Detallesgrupos
    {
        public uint Detallegrupid { get; set; }
        public uint Maestroid { get; set; }
        public uint Grupoid { get; set; }
        public uint Periodoid { get; set; }

        public virtual Grupos Grupo { get; set; }
        public virtual Maestros Maestro { get; set; }
        public virtual Periodos Periodo { get; set; }
    }
}
