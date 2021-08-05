using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Ingrese Primer Nombre")]
        public string Nombre1 { get; set; }
        [Required(ErrorMessage = "Ingrese Segundo Nombre")]
        public string Nombre2 { get; set; }
        [Required(ErrorMessage = "Ingrese Primer Apellido")]
        public string Apellido1 { get; set; }
        [Required(ErrorMessage = "Ingrese Segundo Apellido")]
        public string Apellido2 { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha De Nacimiento")]
        public DateTime Fechanacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese Sexo, M para Hombre, F para Mujer")]
        public string Sexo { get; set; }

        public virtual ICollection<Padreshijos> Padreshijos { get; set; }
        public virtual ICollection<Tallazapatos> Tallazapatos { get; set; }
    }
}
