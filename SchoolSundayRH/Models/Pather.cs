using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSundayRH.Models
{
    public class Pather
    {
        public Pather()
        {
            this.listapatherson = new List<PatherSon1>();
        }
        public string Nombre1 { get; set; }
        public string Apellido1 { get; set; }
        public virtual List<PatherSon1> listapatherson { get; set; }
        //public List<PatherSon1> listapatherson { get; set; }
    }
    public class PatherSon1    {
        public uint Padreid { get; set; }
        public uint Childid { get; set; }
    }
}
