using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;

namespace SchoolSundayRH.Repository
{
    public class GradoRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Grados> GetGrados()
        {
            List<Grados> listGrados = null;
            listGrados = (from gd in dbSchoolSunday.Grados

                          select new Grados
                          {
                              Gradoid = gd.Gradoid,
                              Descripcion = gd.Descripcion

                          }
                         ).ToList();
            return listGrados;
        }
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GradoSelected()
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> gradolist = (from grads in dbSchoolSunday.Grados.AsEnumerable()
                                                                                 select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem

                                                                                 {
                                                                                     Text = grads.Descripcion,
                                                                                     Value = grads.Gradoid.ToString()

                                                                                 }).ToList();
            return gradolist;
        }
    }
    
}
