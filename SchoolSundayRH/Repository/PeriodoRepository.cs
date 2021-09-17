using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSundayRH.Models;
namespace SchoolSundayRH.Repository
{
    public class PeriodoRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Periodos> GetListFromPeriodos()
        {
            List<Periodos> lstperiodos = null;
            lstperiodos = (from periodos in dbSchoolSunday.Periodos                        
                           where periodos.Estado == "A"
                           select periodos).ToList();

            return lstperiodos;
        }
    }
}
