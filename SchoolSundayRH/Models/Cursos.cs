using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Cursosdocentes = new HashSet<Cursosdocentes>();
            Cursosniveles = new HashSet<Cursosniveles>();
            Cursotipoevaluacion = new HashSet<Cursotipoevaluacion>();
        }

        public uint Cursoid { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cursosdocentes> Cursosdocentes { get; set; }
        public virtual ICollection<Cursosniveles> Cursosniveles { get; set; }
        public virtual ICollection<Cursotipoevaluacion> Cursotipoevaluacion { get; set; }
    }
}
