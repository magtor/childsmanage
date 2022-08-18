using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Turnos
    {
        public Turnos()
        {
            Detallessecciones = new HashSet<Detallessecciones>();
        }

        public uint Turnoid { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Detallessecciones> Detallessecciones { get; set; }
    }
}
