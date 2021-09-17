using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Maestros
    {
        public Maestros()
        {
            Cursosdocentes = new HashSet<Cursosdocentes>();
            Detallesgrupos = new HashSet<Detallesgrupos>();
        }

        public uint Maestroid { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Cursosdocentes> Cursosdocentes { get; set; }
        public virtual ICollection<Detallesgrupos> Detallesgrupos { get; set; }
    }
}
