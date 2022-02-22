using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.Repository;

namespace SchoolSundayRH.Controllers
{
    public class PeriodoController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        [HttpGet]
        public IActionResult IndexPeriodos()
        {
            ViewBag.Periodos = dbSchoolSunday.Periodos.ToList();
            return View();
        }
        [Route("CreatePeriodo")]
        public IActionResult CreatePeriodo()
        {
            List<Periodos> lstperiodos = null;
            PeriodoRepository objPeriodoRepositoy = new PeriodoRepository();
            lstperiodos = objPeriodoRepositoy.GetPeriodoAbierto();
            ViewBag.cantrecord = 0;
            if(lstperiodos.Count > 0)
            {
                ViewBag.cantrecord = 1;
                ViewBag.Alert = "ya tenemos un periodo anual activo no puede abrir uno nuevo";
            }

            return View("CreatePeriodo");
        }
        [HttpPost]
        public ActionResult CreatePeriodo1(Periodos periodo)
        {
            if (ModelState.IsValid)
            {
                dbSchoolSunday.Periodos.Add(periodo);
                dbSchoolSunday.SaveChanges();
                return RedirectToAction(nameof(IndexPeriodos));
            }
            else
                return View("CreatePeriodo");

        }
        public ActionResult EditPeriodo(uint id)
        {
            List<Periodos> lstperiodos = null;
            PeriodoRepository objPeriodoRepositoy = new PeriodoRepository();
            lstperiodos = objPeriodoRepositoy.GetListFromPeriodos(id);
            ViewBag.bPeriodos = lstperiodos;
            return View("EditPeriodo", dbSchoolSunday.Periodos.Find(id));
        }
        [HttpPost]        
        public ActionResult EditPeriodo1(uint id, Periodos periodo)
        {
            dbSchoolSunday.Entry(periodo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbSchoolSunday.SaveChanges();
            return RedirectToAction("IndexPeriodos");
        }
    }
}
