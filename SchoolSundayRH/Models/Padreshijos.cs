using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Padreshijos
    {
        public uint Phid { get; set; }
        public uint Padreid { get; set; }
        public uint Childid { get; set; }

        public virtual Childs Child { get; set; }
        public virtual Padres Padre { get; set; }
    }
}
