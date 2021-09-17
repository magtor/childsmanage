using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSundayRH.Controllers
{
    public class GrupoController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public IActionResult IndexGrupos()
        {
            ViewBag.Grupos = dbSchoolSunday.Grupos.ToList();
            return View();
           
        }
        public IActionResult CreateGrupo()
        {
            return View();
        }
    }
}
