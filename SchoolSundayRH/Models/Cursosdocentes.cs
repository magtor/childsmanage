using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Cursosdocentes
    {
        public uint Cursodocenteid { get; set; }
        public uint Maestroid { get; set; }
        public uint Cursoid { get; set; }

        public virtual Cursos Curso { get; set; }
        public virtual Maestros Maestro { get; set; }
    }
}
