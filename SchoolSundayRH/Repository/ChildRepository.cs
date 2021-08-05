using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;

namespace SchoolSundayRH.Repository
{
    public class ChildRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Maestros> GetTeacher(uint idmaestro)
        {
            List<Maestros> listmaestros = null;
            listmaestros = (from tch in dbSchoolSunday.Maestros
                          where tch.Maestroid == idmaestro
                            select new Maestros
                          {
                              Maestroid = tch.Maestroid,
                              Nombre1 = tch.Nombre1

                          }
                         ).ToList();
            return listmaestros;
        }
    }
}
