using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Repository;
using SchoolSundayRH.Models;

namespace SchoolSundayRH.Controllers
{
    public class TrimestreController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public IActionResult IndexTrimestre()
        {   //vamos a crear un query por que tenemos que hacer una reunion de las tablas trimestre y trimestrenicv 
            TrimestreRepository objtrimestreRepositoy = new TrimestreRepository();

            ViewBag.Trimestres = objtrimestreRepositoy.GetTrimestresNiveles();
            return View();
            
        }
        public IActionResult _CreateTrimestre()
        {
            Trimestre trimestre = new Trimestre();
            return PartialView("_CreateTrimestre", trimestre);
        }
    }
}
