using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSundayRH.ViewModels
{
    public class ChildViewModel
    {
        public uint Childid { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public IFormFile Photo { get; set; }
    }
}
