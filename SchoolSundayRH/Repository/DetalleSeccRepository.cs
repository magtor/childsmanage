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
        public List<Detallessecciones> GetListDetalleSecciones(uint id)
        {
            List<Detallessecciones> lstdetallesecciones = null;
            lstdetallesecciones = (from detsections in dbSchoolSunday.Detallessecciones 
                                   where detsections.Detalleseccionid == id

                                   select detsections
                                   ).ToList();
            return lstdetallesecciones;
        }
        public int ContarRegistroDetalleSeccion(uint seccionid,uint periodoid,uint gradoid, uint nivelid,uint turnoid)
        {
            int conta = 0;
            List<Detallessecciones> lstdetallesecc = null;
            lstdetallesecc = (from detsections in dbSchoolSunday.Detallessecciones
                                   where detsections.Seccionid == seccionid
                                   where detsections.Periodoid == periodoid
                                   where detsections.Gradoid == gradoid
                                   where detsections.Nivelid == nivelid
                                   where detsections.Turnoid == turnoid
                              select detsections
                                  ).ToList();

            conta = lstdetallesecc.Count;
            return conta;

        }
    }
    
}
