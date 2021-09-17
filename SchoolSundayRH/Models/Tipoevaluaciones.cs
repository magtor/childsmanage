using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Tipoevaluaciones
    {
        public Tipoevaluaciones()
        {
            Cursotipoevaluacion = new HashSet<Cursotipoevaluacion>();
        }

        public uint Tipoevaluacionid { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cursotipoevaluacion> Cursotipoevaluacion { get; set; }
    }
}
