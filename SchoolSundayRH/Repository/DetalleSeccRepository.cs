using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.ViewModels;
namespace SchoolSundayRH.Repository
{
    
    public class DetalleSeccRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<SeccionRegViewModel> GetListDetSeccioReg()
        {
            List<SeccionRegViewModel> lstsecciones = null;
            lstsecciones = (from detsections in dbSchoolSunday.Detallessecciones
                            join section in dbSchoolSunday.Secciones on detsections.Seccionid equals section.Seccionid
                            join grados in dbSchoolSunday.Grados on detsections.Gradoid equals grados.Gradoid
                            join levels in dbSchoolSunday.Niveles on detsections.Nivelid equals levels.Nivelid


                            select new SeccionRegViewModel
                            {
                                Detalleseccionid = detsections.Detalleseccionid,
                                LetraDescripcion = section.Descripcion,
                                GradoDescripcion = grados.Descripcion,
                                NivelDescripcion = levels.Descripcion,
                                Capacidad = detsections.Capacidad

                            }).ToList();


            return lstsecciones;
        }
    }
}
