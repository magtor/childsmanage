using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Repository;
using SchoolSundayRH.Models;


namespace SchoolSundayRH.Controllers
{
    public class NivelController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public IActionResult IndexNivel()
        {
            List<Niveles> lstniveles = null;
            NivelesRepository objNivelesRepository = new NivelesRepository();
            lstniveles = objNivelesRepository.GetNiveles();
            ViewBag.niveles = lstniveles;

            return View();
        }
        [HttpGet]
        [Route("_CreateNivel")]
        public ActionResult _CreateNivel()
        {
            Niveles nivel = new Niveles();
            return PartialView("_CreateNivel", nivel);
        }
        [Route("CreateNivel1")]
        [HttpPost]
        public ActionResult CreateNivel1(Niveles nivel)
        {
            dbSchoolSunday.Niveles.Add(nivel);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexNivel));
            //return PartialView("_CreateMaster", master);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
