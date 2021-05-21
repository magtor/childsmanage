using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Childs
    {
        public Childs()
        {
            Padreshijos = new HashSet<Padreshijos>();
            Tallazapatos = new HashSet<Tallazapatos>();
        }

        public uint Childid { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Padreshijos> Padreshijos { get; set; }
        public virtual ICollection<Tallazapatos> Tallazapatos { get; set; }
    }
}
