using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Matriculas
    {
        public Matriculas()
        {
            Detallematriculas = new HashSet<Detallematriculas>();
        }

        public uint Matriculaid { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public ushort? Yearlectivo { get; set; }

        public virtual ICollection<Detallematriculas> Detallematriculas { get; set; }
    }
}
