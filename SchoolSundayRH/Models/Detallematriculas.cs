using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Detallematriculas
    {
        public uint Detallematrid { get; set; }
        public uint Childid { get; set; }
        public uint Periodoid { get; set; }
        public uint Seccionid { get; set; }
        public uint Gradoid { get; set; }
        public DateTime Fechamatricula { get; set; }
        public string Certmedico { get; set; }
        public string Libretaest { get; set; }

        public virtual Childs Child { get; set; }
        public virtual Grados Grado { get; set; }
        public virtual Periodos Periodo { get; set; }
        public virtual Secciones Seccion { get; set; }
    }
}
