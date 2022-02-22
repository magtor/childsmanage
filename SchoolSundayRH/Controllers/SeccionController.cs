using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Repository;
using SchoolSundayRH.ViewModels;
using SchoolSundayRH.Models;


namespace SchoolSundayRH.Controllers
{
    public class SeccionController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public IActionResult IndexSecciones()
        {
            //listar las letras o secciones
            ViewBag.Secciones = dbSchoolSunday.Secciones.ToList();
            return View();
         
        }
        [HttpGet]
        [Route("_CreateSeccion")]
        public ActionResult _CreateSeccion()
        {
            Secciones seccion = new Secciones();
            return PartialView("_CreateSeccion", seccion);
        }
        [Route("CreateSeccion1")]
        [HttpPost]
        public ActionResult CreateSeccion1(Secciones seccion)
        {
            dbSchoolSunday.Secciones.Add(seccion);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexSecciones));
            //return PartialView("_CreateMaster", master);
        }
    }
}
