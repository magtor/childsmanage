﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Grupos
    {
        public Grupos()
        {
            Detallesgrupos = new HashSet<Detallesgrupos>();
        }

        public uint Grupoid { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Detallesgrupos> Detallesgrupos { get; set; }
    }
}
