using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSundayRH.Models;
namespace SchoolSundayRH.Repository
{
    public class PeriodoRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Periodos> GetPeriodoAbierto()
        {
            List<Periodos> lstperiodos = null;
            lstperiodos = (from periodos in dbSchoolSunday.Periodos                        
                           where periodos.Estado == "A"
                           select periodos).ToList();

            return lstperiodos;
        }
        public List<Periodos> GetListFromPeriodos(uint idPeriodo)
        {
            List<Periodos> lstperiodos = null;
            lstperiodos = (from periodos in dbSchoolSunday.Periodos
                           where periodos.Periodoid == idPeriodo
                           select periodos).ToList();

            return lstperiodos;
        }
    }
}
