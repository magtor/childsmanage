
using System.Collections.Generic;
using System.Linq;
using System;
using SchoolSundayRH.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace SchoolSundayRH.Repository
{
    public class TipoEvaluacionRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Tipoevaluaciones> GetTipoDeEvaluaciones()
        {
            List<Tipoevaluaciones> listTipoEvaluaciones = null;
            listTipoEvaluaciones = (from tpeva in dbSchoolSunday.Tipoevaluaciones

                          select new Tipoevaluaciones
                          {
                              Tipoevaluacionid = tpeva.Tipoevaluacionid,
                              Descripcion = tpeva.Descripcion

                          }
                         ).ToList();
            return listTipoEvaluaciones;
        }
        public List<SelectListItem> GetTipoEvaluacionesSelect()
        {
            List<SelectListItem> tipolist = (from tipoevaluacion in dbSchoolSunday.Tipoevaluaciones
                                              select new SelectListItem
                                              {
                                                  Text = tipoevaluacion.Descripcion,
                                                  Value = tipoevaluacion.Tipoevaluacionid.ToString()

                                              }).ToList();
            return tipolist;
        }
        public int[] GetTipoEvaluacionIDs(uint idcurso)
        {
            int[] Ids;
            int cont = 0;
            var  ListIdcursotevaluacion = from cursotevaluacion in dbSchoolSunday.Cursotipoevaluacion 
                                          where cursotevaluacion.Cursoid == idcurso 
                                           select new 
                                           {
                                               Tipoevaluacionid = cursotevaluacion.Tipoevaluacionid

                                           };
            Ids = new int[ListIdcursotevaluacion.Count()];
            if (ListIdcursotevaluacion.Count() > 0)
            {
                
                foreach (var item in ListIdcursotevaluacion)
                {
                    Ids[cont] = Convert.ToInt32(item.Tipoevaluacionid);
                    cont = cont + 1;
                }
            }
            return Ids;
        }
        public int SaveTipoEvaluaciones(IFormCollection formcurso)
        {
            int salvado = 0;
            int idcurso = Convert.ToInt32(formcurso["Cursoid"]);
            foreach (var item in formcurso["TipoEvaluacionIDs"])
            {           

                var cursotipeval = new Cursotipoevaluacion()
                {
                    Cursoid = Convert.ToUInt32(idcurso),
                    Tipoevaluacionid = Convert.ToUInt32(Int32.Parse(item))
                };
                dbSchoolSunday.Cursotipoevaluacion.Add(cursotipeval);
                
            }
            if (dbSchoolSunday.SaveChanges() > 0)
            {
                salvado = 1;
            }
            return salvado;
        }
    }
}
