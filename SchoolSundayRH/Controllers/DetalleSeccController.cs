using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Repository;
using SchoolSundayRH.ViewModels;
using SchoolSundayRH.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolSundayRH.Controllers
{
    public class DetalleSeccController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        // GET: DetalleSeccController
        public ActionResult IndexDetalleSecc(int pg=1)
        {   // ViewBag.Secciones = dbSchoolSunday.Periodos.ToList();
            //vamos a crear una reunion de las tablas de nivel y seccion para obtener el nivel y la seccion
            DetalleSeccRepository objdetalleSeciondRepositoy = new DetalleSeccRepository();
            List<SeccionRegViewModel> datossecciones ;
            datossecciones = objdetalleSeciondRepositoy.GetListDetSeccioReg();

            const int pagesize = 5;
            if(pg < 1)           
                pg = 1;
           
            int recsCount = datossecciones.Count();
            var paginador = new PaginatedList(recsCount,pg,pagesize);
            int recSkip = (pg - 1) * pagesize;
            var data = datossecciones.Skip(recSkip).Take(paginador.PageSize).ToList();
            ViewBag.Pager = paginador;

           // ViewBag.DetalleSec = datossecciones;
            return View(data);
        }

        // GET: DetalleSeccController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleSeccController/Create
        public ActionResult _CreateDetalleSecc()
        {
            //Para aclarar si necesitamos la tabla secciones pero semanticamente sera una letra
            //el codigo a continuacion lo pasaremos al controlador detallesecciones
            //aca solo tendremos el codigo de crear una letra observemos el minuto 5 del video sistema para colegios
            List<Grados> lstgrados = null;
            List<Niveles> lstniveles = null;
            List<Secciones> lstsecciones = null;
            List<Periodos> lstperiodos = null;
            List<Turnos> lstturnos = null;

            NivelesRepository objNivelesRepository = new NivelesRepository();
            lstniveles = objNivelesRepository.GetNiveles();

            GradoRepository objGradoRepositoy = new GradoRepository();
            lstgrados = objGradoRepositoy.GetGrados();
            LetraRepository objLetrasRepository = new LetraRepository();

            lstsecciones = objLetrasRepository.getLetras();//secciones o letras es lo mismo
            PeriodoRepository objPeriodoRepositoy = new PeriodoRepository();
            lstperiodos = objPeriodoRepositoy.GetPeriodoAbierto();

            TurnoRepository objTTurnoRepository = new TurnoRepository();
            lstturnos = objTTurnoRepository.GetTurnos();

            ViewBag.periodo = 0;
            foreach(Periodos periodoactivo in lstperiodos)
            {
                ViewBag.periodo = periodoactivo.Periodoid;
            }

            List<SelectListItem> itemsgrados = lstgrados.ConvertAll(ch =>
            {
                return new SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Gradoid.ToString(),
                };
            });
            ViewBag.ItemGrados = itemsgrados;

            List<SelectListItem> itemsniveles = lstniveles.ConvertAll(ch =>
            {
                return new SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Nivelid.ToString(),
                };
            });
            ViewBag.ItemNiveles = itemsniveles;

            List<SelectListItem> itemsletras = lstsecciones.ConvertAll(ch =>
            {
                return new SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Seccionid.ToString(),
                };
            });
            ViewBag.Itemletras = itemsletras;
             List<SelectListItem> itemsturnos = lstturnos.ConvertAll(ch =>
            {
                return new SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Turnoid.ToString(),
                };
            });
            ViewBag.Itemturnos = itemsturnos;

            return PartialView("_CreateDetalleSecc");
        }
        //El error puede ser por que no estamos guardando el id del periodo, 
        //este id es posible recuperarlo para eso se usara el metodo GetPeriodoAbierto
        //este metodo esta en la clase PeriodoRepository
        //Ya entendi a que se debe el error se tiene que obtener los valores de id de secciones, grados y niveles de cada
        // DropDownList esto lo tenemos que hacer en Jquery y se lo vamos a asignar a los controles ocultos que declare en la vista _CreateDetalleSecc
        //queda investigar como disparar un evento en los DropDownList que me permita obtener el id seleccionado
        // POST: DetalleSeccController/Create
       
        [HttpPost]
        public ActionResult CreateDetSeccion1(string json)
        {
            /* dbSchoolSunday.Detallessecciones.Add(detsecciones);
             dbSchoolSunday.SaveChanges();
             return RedirectToAction(nameof(IndexDetalleSecc));*/
            DetalleSeccRepository objdetalleSeciondRepositoy = new DetalleSeccRepository();
            Detallessecciones detsecc  = JsonConvert.DeserializeObject<Detallessecciones>(json);
            
            var nuevodetsecc = new Detallessecciones()
            {
               Capacidad = detsecc.Capacidad,
               Seccionid = detsecc.Seccionid,
               Vacantes = detsecc.Vacantes,
               Periodoid = detsecc.Periodoid,
               Gradoid = detsecc.Gradoid,
               Nivelid = detsecc.Nivelid,
               Turnoid = detsecc.Turnoid
            };
            //validamos que no se repita el registro es decir no podmeos crear una seccion A Del turno tal
            int contabdetseccrec = objdetalleSeciondRepositoy.ContarRegistroDetalleSeccion(detsecc.Seccionid,
               detsecc.Periodoid, detsecc.Gradoid, detsecc.Nivelid, detsecc.Turnoid);
            if (contabdetseccrec == 0)
            {
                dbSchoolSunday.Detallessecciones.Add(nuevodetsecc);
                dbSchoolSunday.SaveChanges();

            }
            return RedirectToAction(nameof(IndexDetalleSecc));
        }
        [HttpGet]
        [Route("_EditarDetalleSecc/{id}")]
        public ActionResult _EditarDetalleSecc(uint id)
        {
            //seleccionaremos el registro correspondiente a la seccion, para obtener el id de letra, id de grado,id de nivel
            //para ellos vamos a hacer un select en la tabla detallesecciones usando el id que recibimos en el action result
            DetalleSeccRepository objDetalleSecciones = new DetalleSeccRepository();
            List<Detallessecciones> listdetallesecciones = null;
            
            listdetallesecciones = objDetalleSecciones.GetListDetalleSecciones(id);
            LetraRepository objLetrasRepository = new LetraRepository();            
            
            List<SelectListItem> letralist = objLetrasRepository.LetraSelected();

            GradoRepository objGradosRepository = new GradoRepository();
            List<SelectListItem> gradolist = objGradosRepository.GradoSelected();

            NivelesRepository objNivelRepository = new NivelesRepository();
            List<SelectListItem> nivellist = objNivelRepository.NivelSelected();

            foreach (var detasection in listdetallesecciones)
            {
                letralist.Find(c => c.Value == detasection.Seccionid.ToString()).Selected = true;
                ViewBag.Itemletras = letralist;

                gradolist.Find(c => c.Value == detasection.Gradoid.ToString()).Selected = true;
                ViewBag.ItemGrados = gradolist;

                nivellist.Find(c => c.Value == detasection.Nivelid.ToString()).Selected = true;
                ViewBag.ItemNiveles = nivellist;
                ViewBag.periodo = detasection.Periodoid;
                ViewBag.capacidad = detasection.Capacidad;
                ViewBag.iddetsecc = detasection.Detalleseccionid;
            }
            

            //Set the Item with ID '2' as Selected.
           // leerlist.Find(c => c.Value == "2").Selected = true;
            return PartialView("_EditarDetalleSecc");
        }

        [HttpPost]
        //[Route("EditarDetalleSecc1")]
        public ActionResult EditarDetalleSecc1(string json)
        {
            Detallessecciones detsecc = JsonConvert.DeserializeObject<Detallessecciones>(json);
            DetalleSeccRepository objdetalleSeciondRepositoy = new DetalleSeccRepository();

            Detallessecciones detsecsearch = 
                dbSchoolSunday.Detallessecciones.Where(f => f.Detalleseccionid == detsecc.Detalleseccionid).FirstOrDefault();
            detsecsearch.Capacidad = detsecc.Capacidad;
            detsecsearch.Seccionid = detsecc.Seccionid;
            detsecsearch.Vacantes = detsecc.Vacantes;
            detsecsearch.Periodoid = detsecc.Periodoid;
            detsecsearch.Gradoid = detsecc.Gradoid;
            detsecsearch.Nivelid = detsecc.Nivelid;
            detsecsearch.Turnoid = detsecc.Turnoid;
            //validamos que no se repita el registro es decir no podmeos crear una seccion A Del turno tal
            int contabdetseccrec = objdetalleSeciondRepositoy.ContarRegistroDetalleSeccion(detsecc.Seccionid,
                detsecc.Periodoid, detsecc.Gradoid, detsecc.Nivelid, detsecc.Turnoid);
            if (contabdetseccrec > 0)
            {
                dbSchoolSunday.Entry(detsecsearch).State = EntityState.Modified;
                dbSchoolSunday.SaveChanges();            }
              

            return RedirectToAction(nameof(IndexDetalleSecc));
        }

    }
}
