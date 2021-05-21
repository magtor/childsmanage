using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class Trimestreyear
    {
        public uint Tyearid { get; set; }
        public int Trimestre { get; set; }
        public string Year { get; set; }
        public int Cantdomingos { get; set; }
    }
}
