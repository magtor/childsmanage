using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Periodos
    {
        public Periodos()
        {
            Detallematriculas = new HashSet<Detallematriculas>();
            Detallesgrupos = new HashSet<Detallesgrupos>();
            Detallessecciones = new HashSet<Detallessecciones>();
            Horariosniveles = new HashSet<Horariosniveles>();
        }

        public uint Periodoid { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafin { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Detallematriculas> Detallematriculas { get; set; }
        public virtual ICollection<Detallesgrupos> Detallesgrupos { get; set; }
        public virtual ICollection<Detallessecciones> Detallessecciones { get; set; }
        public virtual ICollection<Horariosniveles> Horariosniveles { get; set; }
    }
}
