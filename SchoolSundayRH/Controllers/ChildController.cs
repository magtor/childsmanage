using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.Repository;
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

        //[Route("Create1")]
        [HttpPost]
        public ActionResult Create1(Childs child)
        {
            if (ModelState.IsValid) { 
             dbSchoolSunday.Childs.Add(child);
             dbSchoolSunday.SaveChanges();
              return RedirectToAction(nameof(Index));
            }
            else
              return View("Create");

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
        
        public ActionResult Edit1(int id, Childs child)
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
        public ActionResult TomarAsistencia()
        {
            ChildRepository objChildRepositoy = new ChildRepository();
            List<Maestros> lstteachers = null;
            //crearemos un Select donde podremos escoger el maestro.
            lstteachers = objChildRepositoy.ListTeachers();
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ItemsMaestros = lstteachers.ConvertAll(ch =>
            {
                return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = ch.Nombre1.ToString(),
                    Value = ch.Maestroid.ToString(),
                };
            });
            ViewBag.ItemsTeacher = ItemsMaestros;
            return View("PasarLista");
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
