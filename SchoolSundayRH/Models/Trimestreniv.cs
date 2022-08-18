using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Trimestreniv
    {
        public uint Trimestrenivid { get; set; }
        public uint Trimestreid { get; set; }
        public uint Nivelid { get; set; }

        public virtual Niveles Nivel { get; set; }
        public virtual Trimestre Trimestre { get; set; }
    }
}
