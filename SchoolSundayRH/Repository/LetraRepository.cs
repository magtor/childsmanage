using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;

namespace SchoolSundayRH.Repository
{
    public class LetraRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Secciones> getLetras()
        {
            List<Secciones> listSecciones = null;
            listSecciones = (from sc in dbSchoolSunday.Secciones

                          select new Secciones
                          {
                              Seccionid = sc.Seccionid,
                              Descripcion = sc.Descripcion

                          }
                         ).ToList();
            return listSecciones;
        }
    }
}
