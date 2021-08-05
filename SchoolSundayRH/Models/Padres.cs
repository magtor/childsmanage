using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Padres
    {
        public Padres()
        {
            Padreshijos = new HashSet<Padreshijos>();
        }

        public uint Padreid { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Padreshijos> Padreshijos { get; set; }
    }
}
