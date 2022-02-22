using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Detallessecciones
    {
        public int Detalleseccionid { get; set; }
        public int Capacidad { get; set; }
        public uint Seccionid { get; set; }
        public int Vacantes { get; set; }
        public uint Periodoid { get; set; }
        public uint Gradoid { get; set; }
        public uint Nivelid { get; set; }

        public virtual Grados Grado { get; set; }
        public virtual Niveles Nivel { get; set; }
        public virtual Periodos Periodo { get; set; }
        public virtual Secciones Seccion { get; set; }
    }
}
