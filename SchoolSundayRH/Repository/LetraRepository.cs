using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSundayRH.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolSundayRH.Repository
{
    public class LetraRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Secciones> getLetras()
        {
            List<Secciones> listSecciones = null;
            listSecciones = (from sc in dbSchoolSunday.Secciones

                          select new Secciones
                          {
                              Seccionid = sc.Seccionid,
                              Descripcion = sc.Descripcion

                          }
                         ).ToList();
            return listSecciones;
        }
        public List<SelectListItem> LetraSelected()        
        {
            List<SelectListItem> letralist = (from leter in dbSchoolSunday.Secciones.AsEnumerable()
                                                                                 select new SelectListItem 
        
                                                                                 {
                                                                                     Text = leter.Descripcion,
                                                                                     Value = leter.Seccionid.ToString()

                                                                                 }).ToList();
            return letralist;
        }
    }
}
