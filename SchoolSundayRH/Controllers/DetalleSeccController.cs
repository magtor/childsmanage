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


namespace SchoolSundayRH.Controllers
{
    public class DetalleSeccController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        // GET: DetalleSeccController
        public ActionResult IndexDetalleSecc()
        {   // ViewBag.Secciones = dbSchoolSunday.Periodos.ToList();
            //vamos a crear una reunion de las tablas de nivel y seccion para obtener el nivel y la seccion
            DetalleSeccRepository objdetalleSeciondRepositoy = new DetalleSeccRepository();
            List<SeccionRegViewModel> datossecciones = null;
            datossecciones = objdetalleSeciondRepositoy.GetListDetSeccioReg();
            ViewBag.DetalleSec = datossecciones;
            return View();
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

            NivelesRepository objNivelesRepository = new NivelesRepository();
            lstniveles = objNivelesRepository.GetNiveles();

            GradoRepository objGradoRepositoy = new GradoRepository();
            lstgrados = objGradoRepositoy.GetGrados();
            LetraRepository objLetrasRepository = new LetraRepository();

            lstsecciones = objLetrasRepository.getLetras();//secciones o letras es lo mismo
            PeriodoRepository objPeriodoRepositoy = new PeriodoRepository();
            lstperiodos = objPeriodoRepositoy.GetPeriodoAbierto();
            ViewBag.periodo = 0;
            foreach(Periodos periodoactivo in lstperiodos)
            {
                ViewBag.periodo = periodoactivo.Periodoid;
            }

            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> itemsgrados = lstgrados.ConvertAll(ch =>
            {
                return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Gradoid.ToString(),
                };
            });
            ViewBag.ItemGrados = itemsgrados;

            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> itemsniveles = lstniveles.ConvertAll(ch =>
            {
                return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Nivelid.ToString(),
                };
            });
            ViewBag.ItemNiveles = itemsniveles;

            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> itemsletras = lstsecciones.ConvertAll(ch =>
            {
                return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = ch.Descripcion.ToString(),
                    Value = ch.Seccionid.ToString(),
                };
            });
            ViewBag.Itemletras = itemsletras;
            return PartialView("_CreateDetalleSecc");
        }
        //el error puede ser por que no estamos guardando el id del periodo, 
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
            Detallessecciones detsecc  = JsonConvert.DeserializeObject<Detallessecciones>(json);
            var nuevodetsecc = new Detallessecciones()
            {
               Capacidad = detsecc.Capacidad,
               Seccionid = detsecc.Seccionid,
               Vacantes = detsecc.Vacantes,
               Periodoid = detsecc.Periodoid,
               Gradoid = detsecc.Gradoid,
               Nivelid = detsecc.Nivelid
            };
            dbSchoolSunday.Detallessecciones.Add(nuevodetsecc);
            dbSchoolSunday.SaveChanges();

            return RedirectToAction(nameof(IndexDetalleSecc));
        }       

       
    }
}
