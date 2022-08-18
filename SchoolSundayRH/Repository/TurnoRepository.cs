using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.ViewModels;
namespace SchoolSundayRH.Repository


{
    public class TurnoRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Turnos> GetTurnos()
        {
            List<Turnos> listTurnos = null;
            listTurnos = (from tn in dbSchoolSunday.Turnos

                          select new Turnos
                          {
                              Turnoid = tn.Turnoid,
                              Descripcion = tn.Descripcion

                          }
                         ).ToList();
            return listTurnos;
        }
    }
}
