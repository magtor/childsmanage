using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSundayRH.Models;
namespace SchoolSundayRH.Repository
{    
    public class NivelesRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Niveles> GetNiveles()
        {
            List<Niveles> lisNiveles = null;
            lisNiveles = (from nv in dbSchoolSunday.Niveles

                          select new Niveles
                          {
                              Nivelid = nv.Nivelid,
                              Descripcion = nv.Descripcion

                          }
                         ).ToList();
            return lisNiveles;
        }
        public List<SelectListItem> NivelSelected()
        {
            List<SelectListItem> nivellist = (from levels in dbSchoolSunday.Niveles.AsEnumerable()
                                                                                 select new SelectListItem

                                                                                 {
                                                                                     Text = levels.Descripcion,
                                                                                     Value = levels.Nivelid.ToString()

                                                                                 }).ToList();
            return nivellist;
        }
    }
}
