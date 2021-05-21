using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;

namespace SchoolSundayRH
{
    public class MasterController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        // GET: MasterController
        [Route("IndexMaster")]
        [HttpGet]
        public ActionResult IndexMaster()
        {
            ViewBag.Masters = dbSchoolSunday.Maestros.ToList();
            return View();
            
        }

        // GET: MasterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterController/Create
        [HttpGet]
        [Route("_CreateMaster")]
        public ActionResult _CreateMaster()
        {
            Maestros master = new Maestros();
            return PartialView("_CreateMaster",master);
        }

        // POST: MasterController/Create
        [Route("CreateMaster1")]
        [HttpPost]
        
        public ActionResult CreateMaster1(Maestros master)
        {
            dbSchoolSunday.Maestros.Add(master);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexMaster));
            //return PartialView("_CreateMaster", master);
        }

        // GET: MasterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
