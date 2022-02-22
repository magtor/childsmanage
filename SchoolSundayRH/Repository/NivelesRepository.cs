using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
namespace SchoolSundayRH.Repository
{    
    public class NivelesRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Niveles> GetNiveles()
        {
            List<Niveles> lisNiveles = null;
            lisNiveles = (from nv in dbSchoolSunday.Niveles

                          select new Niveles
                          {
                              Nivelid = nv.Nivelid,
                              Descripcion = nv.Descripcion

                          }
                         ).ToList();
            return lisNiveles;
        }

    }
}
