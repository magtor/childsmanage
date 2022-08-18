using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;


namespace SchoolSundayRH.Repository
{
    public class CursoRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Cursos> GetCurso(uint id)
        {
            List<Cursos> lstcursos = null;
            lstcursos = (from cur in dbSchoolSunday.Cursos
                                   where cur.Cursoid == id

                                   select cur
                                   ).ToList();
            return lstcursos;
        }
    }
}
