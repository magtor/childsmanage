﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Niveles
    {
        public Niveles()
        {
            Cursosniveles = new HashSet<Cursosniveles>();
            Detallessecciones = new HashSet<Detallessecciones>();
            Horariosniveles = new HashSet<Horariosniveles>();
            Trimestreniv = new HashSet<Trimestreniv>();
        }

        public uint Nivelid { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cursosniveles> Cursosniveles { get; set; }
        public virtual ICollection<Detallessecciones> Detallessecciones { get; set; }
        public virtual ICollection<Horariosniveles> Horariosniveles { get; set; }
        public virtual ICollection<Trimestreniv> Trimestreniv { get; set; }
    }
}
