using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Repository;
using SchoolSundayRH.Models;

namespace SchoolSundayRH.Controllers
{
    public class GradoController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public IActionResult IndexGrados()
        {
            List<Grados> lstgrados = null;
            GradoRepository objGradoRepositoy = new GradoRepository();
            lstgrados = objGradoRepositoy.GetGrados();
            ViewBag.grados = lstgrados;

            return View();
        }
        [HttpGet]
        [Route("_CreateGrado")]
        public ActionResult _CreateGrado()
        {
            Grados grado = new Grados();
            return PartialView("_CreateGrado", grado);
        }
        [Route("CreateGrado1")]
        [HttpPost]
        public ActionResult CreateGrado1(Grados grado)
        {
            dbSchoolSunday.Grados.Add(grado);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexGrados));
            //return PartialView("_CreateMaster", master);
        }
    }
}
