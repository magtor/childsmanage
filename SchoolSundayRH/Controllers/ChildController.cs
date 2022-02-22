using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.ViewModels;
using SchoolSundayRH.Repository;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SchoolSundayRH.Controllers
{
    public class ChildController : Controller
    {

        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        private readonly IWebHostEnvironment hostingEnviroment;
        public ChildController(IWebHostEnvironment hostingEnviroment)
        {
            this.hostingEnviroment = hostingEnviroment;
        }

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
        //[Route("CreateChild")]
        [HttpGet]
        public ActionResult CreateChild()
        {
            return View();
        }

        // POST: ChildController/Create      

        //[Route("Create1")]
        [HttpPost]
        public ActionResult Create1(ChildViewModel modelchild)
        {
            if (ModelState.IsValid) {
                //insertamos la foto en la carpeta WebRoot especificamente en la subcarpeta images
                string uniqueFileName = null;
                if (modelchild.Photo.Length > 0)
                {
                    string uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + modelchild.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        modelchild.Photo.CopyTo(fileStream);
                    }
                }
                Childs newChilds = new Childs
                {
                    Nombre1 = modelchild.Nombre1,
                    Nombre2 = modelchild.Nombre2,
                    Apellido1 = modelchild.Apellido1,
                    Apellido2 = modelchild.Apellido2,
                    Fechanacimiento = modelchild.Fechanacimiento,
                    Sexo = modelchild.Sexo,
                    Direccion = "Ave Modesto Duarte Boaco",
                    Photo = uniqueFileName

                };

                dbSchoolSunday.Childs.Add(newChilds);
                dbSchoolSunday.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
              return View("Create");

        }

        // GET: ChildController/Edit/5
        [HttpGet]
        [Route("edit/{id}") ]
        public ActionResult EditChild(uint id)
        {
            ViewBag.Childs1 = from childs in dbSchoolSunday.Childs
                             where childs.Childid == id
                             select childs;
            return View();
        }

        // POST: ChildController/Edit/5
        [HttpPost]
        
        public ActionResult Edit1(uint id, ChildViewModel modelchild)
        {
            //Ver si hay un archivo anterior para borrarlo
            ChildRepository objChildRepositoy = new ChildRepository();
            List<Childs> datosnene = null;
            datosnene = objChildRepositoy.DatosNene(modelchild.Childid);
            foreach (var dato in datosnene)
            {
                if (!String.IsNullOrEmpty(dato.Photo))
                {
                    string filedelete = Path.Combine(hostingEnviroment.WebRootPath, "images",dato.Photo);
                    FileInfo fi = new FileInfo(filedelete);
                    if(fi != null)
                    {
                        System.IO.File.Delete(filedelete);
                        fi.Delete();
                    }
                }
            }
            
            if (ModelState.IsValid)
            {   //Esto Lo Vamos a poner en un metodo de la clase ChildRepository
                //codigo que se repite en el ActionResult Create1
                string uniqueFileName = null;
                if (modelchild.Photo.Length > 0)
                {
                    string uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + modelchild.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        modelchild.Photo.CopyTo(fileStream);
                    }
                   
                }
                //ahora vamos a actualizar el registro del niño
                var entity = dbSchoolSunday.Childs.FirstOrDefault(item => item.Childid == modelchild.Childid);
                if(entity != null)
                {
                    entity.Nombre1 = modelchild.Nombre1;
                    entity.Nombre2 = modelchild.Nombre2;
                    entity.Apellido1 = modelchild.Apellido1;
                    entity.Apellido2 = modelchild.Apellido2;
                    entity.Sexo = modelchild.Sexo;
                    entity.Photo = uniqueFileName;

                    dbSchoolSunday.Childs.Update(entity);
                    dbSchoolSunday.SaveChanges();
                }

                
            }
            return RedirectToAction(nameof(Index));
            /*try
            {*/
            //vamos a buscar la imagen en el directorio images y la vamos a borrar
            //posteriormente vamos a salvar la imagen actualizada
            /*dbSchoolSunday.Entry(child).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(Index));*/
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
