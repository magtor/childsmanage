using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSundayRH.Models
{
    public class Niño 
    {
        
        public int NiñoId { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }


    }
    public class Maestro
    {
        
        public int MaestroId { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public ICollection<Niño> Niños { get; set; }
    }
    public class Padre
    {
        public int PadreId { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public ICollection<Niño> niños { get; set; }

    }
    public class TallaZapato
    {
        public int TallaZapatoId { get; set; }
        public int Talla { get; set; }
        public int NiñoId { get; set; }
        public Niño Niño { get; set; }
    }

}
