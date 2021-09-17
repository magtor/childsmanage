using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Cursotipoevaluacion
    {
        public uint Cursotipevalid { get; set; }
        public uint Cursoid { get; set; }
        public uint Tipoevaluacionid { get; set; }

        public virtual Cursos Curso { get; set; }
        public virtual Tipoevaluaciones Tipoevaluacion { get; set; }
    }
}
