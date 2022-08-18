using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSundayRH.Repository;
using SchoolSundayRH.Models;


namespace SchoolSundayRH.Controllers
{
    public class TurnoController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public IActionResult IndexTurnos()
        {
            TurnoRepository objTurnoRepository = new TurnoRepository();
            List<Turnos> datosturnos;
            datosturnos = objTurnoRepository.GetTurnos();
            ViewBag.Turnos = datosturnos;
            return View();
        }
        [HttpGet]
        [Route("_CreateTurno")]
        public ActionResult _CreateTurno()
        {
            Turnos turno = new Turnos();
            return PartialView("_CreateTurno", turno);
        }
        [Route("CreateTurno1")]
        [HttpPost]
        public ActionResult CreateTurno1(Turnos turno)
        {
            dbSchoolSunday.Turnos.Add(turno);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexTurnos));
            //return PartialView("_CreateMaster", master);
        }
    }
}
