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
        public List<Maestros> ListTeachers()
        {
            List<Maestros> listmaestros = null;
            listmaestros = (from tch in dbSchoolSunday.Maestros                            
                            select new Maestros
                            {
                                Maestroid = tch.Maestroid,
                                Nombre1 = tch.Nombre1

                            }
                         ).ToList();
            return listmaestros;
        }
        public List<Childs> DatosNene(uint id)
        {
            List<Childs> datanene = null;
            datanene = (from childs in dbSchoolSunday.Childs
                        where childs.Childid == id
                        select childs).ToList();
            return datanene;
        }
    }
}
