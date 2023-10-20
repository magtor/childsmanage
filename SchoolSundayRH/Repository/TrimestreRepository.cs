using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.ViewModels;
namespace SchoolSundayRH.Repository
{
    public class TrimestreRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<TrimestresandNiv> GetTrimestresNiveles()
        { //vamos hacer una reunion de la tabla trimestre y la tabla trimestreniv
          //  estos datos seran presentados en el index de trimestres
            List<TrimestresandNiv> lsttrimestreniv = (from trimniv in dbSchoolSunday.Trimestreniv
                                                      join tri in dbSchoolSunday.Trimestre on trimniv.Trimestreid equals tri.Trimestreid
                                                      join niv in dbSchoolSunday.Niveles on trimniv.Nivelid equals niv.Nivelid

                                                      select new TrimestresandNiv
                                                      {
                                                          Trimestreid = Convert.ToInt32(tri.Trimestreid),
                                                          Fechaini = tri.Fechaini,
                                                          Fechafin = tri.Fechafin,
                                                          NivelDescripcion = niv.Descripcion,
                                                          numero = tri.Numtrimestre

                                                      }).ToList();
            return lsttrimestreniv;                                      
        }
    }
}
