using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
namespace SchoolSundayRH.Controllers
{
    public class ChildController : Controller
    {

        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();

        [Route("Index")]        
        // GET: ChildController
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Childs = dbSchoolSunday.Childs.ToList();
            return View();
        }

        // GET: ChildController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChildController/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ChildController/Create
        [Route("Create1")]
        [HttpPost]       
        public ActionResult Create1(Childs child)
        {
            dbSchoolSunday.Childs.Add(child);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }

        // GET: ChildController/Edit/5
        [HttpGet]
        [Route("edit/{id}") ]
        public ActionResult Edit(uint id)
        {
            return View("Edit", dbSchoolSunday.Childs.Find(id));
        }

        // POST: ChildController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Childs child)
        {
            /*try
            {*/
            dbSchoolSunday.Entry(child).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(Index));
            /*}
            catch
            {*/
                //return View();
            //}
        }

        // GET: ChildController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // GET: ChildController/Delete/5
        

        // POST: ChildController/Delete/5
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
