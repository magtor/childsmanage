using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.Repository;
using Newtonsoft.Json;

namespace SchoolSundayRH.Controllers
{
    public class PatherController : Controller
    {

        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        // GET: PatherController
        [Route("IndexPather")]
        [HttpGet]
        public ActionResult IndexPather()
        {
            ViewBag.Pathers = dbSchoolSunday.Padres.ToList();
            return View();
        }

        // GET: PatherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatherController/Create
        [Route("CreatePather")]
        public ActionResult CreatePather()
        {
            return View();
        }

        // POST: PatherController/Create
        [HttpPost]
        [Route("CreatePather1")]        
        public ActionResult CreatePather1(Padres padre)
        {
            dbSchoolSunday.Padres.Add(padre);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexPather));
        }

        // GET: PatherController/Edit/5
        
        [HttpPost]
        //[Route("CreatePadreHijos")]
        public ActionResult CreatePadreHijos(string json)
        {            
                     
               /* foreach (var itempadreshijos in listpadreshijos)
                {
                    
                    var recordpadreshijos = new Padreshijos()
                    {
                        Padreid = itempadreshijos.listapatherson.Padreid
                        Childid = itempadreshijos.Childid
                    };

                    dbSchoolSunday.Padreshijos.Add(recordpadreshijos);
                    dbSchoolSunday.SaveChanges();
                }*/
              Pather pathersons = JsonConvert.DeserializeObject<Pather>(json);
              foreach (var itempadreshijos in pathersons.listapatherson)
              {
                // Console.WriteLine("Padreid: {0}, Childid: {1}", item.Padreid, item.Childid);
                var recordpadreshijos = new Padreshijos()
                {
                         Padreid = itempadreshijos.Padreid,
                         Childid = itempadreshijos.Childid
                };
                dbSchoolSunday.Padreshijos.Add(recordpadreshijos);
            }
            try
            {
                if (dbSchoolSunday.SaveChanges() > 0)
                {
                    return Json(new { error = false, message = "Order saved successfully" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message });
            }
            return RedirectToAction(nameof(IndexPather));
        }
        [HttpGet]
        [Route("EditPather/{id}")]
        public ActionResult EditPather(uint id)
        {
            return View("EditPather", dbSchoolSunday.Padres.Find(id));

        }

        // POST: PatherController/Edit/5
        [HttpPost]
        //[Route("EditPather1")]
        public ActionResult EditPather1(uint id, Padres padre)
        {
            dbSchoolSunday.Entry(padre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbSchoolSunday.SaveChanges();
            return RedirectToAction("IndexPather") ;
        }
        [HttpGet]
        [Route("_AsociarPadre")]
        public ActionResult _AsociarPadre(uint id)
        {
            var countpatherson = (from ph in dbSchoolSunday.Padreshijos
                                  where ph.Padreid == id
                                  select ph).Count();            
 
            List<Childs> lstchilds= null;
            List<Padres> lstpathers = null;

            PatherRepository objPatherRepositoy = new PatherRepository();
            lstchilds = objPatherRepositoy.GetChilds(countpatherson);

            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> items = lstchilds.ConvertAll(ch =>
            {
                return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = ch.Nombre1.ToString(),
                    Value = ch.Childid.ToString(),
            };
            });

            lstpathers = objPatherRepositoy.GetPadre(id);
            ViewBag.ItemPadre = lstpathers;
            ViewBag.items = items;
            ViewBag.ItemsHijosDePadre = objPatherRepositoy.GetListSonFromPather(id);

            return PartialView("_AsociarPadre");
        }

        // GET: PatherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatherController/Delete/5
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
