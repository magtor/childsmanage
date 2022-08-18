using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using SchoolSundayRH.Repository;
using SchoolSundayRH.Models;


namespace SchoolSundayRH.Controllers
{
    public class CursoController : Controller
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();

        public IActionResult IndexCurso()
        {
            ViewBag.Curso = dbSchoolSunday.Cursos.ToList();
            return View();
        }
        public ActionResult _CreateCurso()
        {
            Cursos curso = new Cursos();
            return PartialView("_CreateCurso", curso);
        }
        [Route("CreateCurso1")]
        [HttpPost]
        public ActionResult CreateCurso1(Cursos curso)
        {
            dbSchoolSunday.Cursos.Add(curso);
            dbSchoolSunday.SaveChanges();
            return RedirectToAction(nameof(IndexCurso));
            //return PartialView("_CreateMaster", master);
        }
        [HttpGet]
        [Route("_EditCurso/{id}")]
        public ActionResult _EditCurso(uint id)
        {
            
            NivelesRepository objNivelRepository = new NivelesRepository();
            List<SelectListItem> nivellist = objNivelRepository.NivelSelected();
            ViewBag.ItemNiveles = nivellist;
            CursoRepository objCurso = new CursoRepository();
            ViewBag.Curso =  objCurso.GetCurso(id);
            //Con las instrucciones siguientes logramos poblar el select cuyo id es FormaEval
            TipoEvaluacionRepository objTipoEvaluacionRepository = new TipoEvaluacionRepository();           
            SelectedTipoEvaluaciones model = new SelectedTipoEvaluaciones();
            model.ItemList = objTipoEvaluacionRepository.GetTipoEvaluacionesSelect();
            if(objTipoEvaluacionRepository.GetTipoEvaluacionesSelect().Count() > 0)
            {//esto permite que se vean los tipos de evaluaciones seleccionadas cuando se abra la ventana de Edicion
                model.TipoEvaluacionIDs = objTipoEvaluacionRepository.GetTipoEvaluacionIDs(id);
                List<SelectListItem> selecteditems = model.ItemList.Where(p => model.TipoEvaluacionIDs.Contains(int.Parse(p.Value))).ToList();
                foreach (var selectitem in selecteditems)
                {
                    selectitem.Selected = true;

                }
            }

           
            model.ID = (int) id;

            return PartialView("_EditCurso", model);
        }
        [HttpGet]
        [Route("_EditCursoP/{id}")]
        public ActionResult _EditCursoP(uint id)
        {

            NivelesRepository objNivelRepository = new NivelesRepository();
            List<SelectListItem> nivellist = objNivelRepository.NivelSelected();
            ViewBag.ItemNiveles = nivellist;
            CursoRepository objCurso = new CursoRepository();
            ViewBag.Curso = objCurso.GetCurso(id);
            //Con las instrucciones siguientes logramos poblar el select cuyo id es FormaEval
            SelectList tipoevaluacion = new SelectList(dbSchoolSunday.Tipoevaluaciones.ToList(), "Tipoevaluacionid", "Descripcion");
            return PartialView("_EditCursoP", tipoevaluacion);
        }
        [HttpPost]
        public ActionResult SaveCursoEdit(SelectedTipoEvaluaciones tipselect, IFormCollection form)
        {
            //int[] idtipoevaluacion;
            int salvado = 0;
            //idtipoevaluacion = new int[form["TipoEvaluacionIDs"].Count()];
           // int cont = 0;
            TipoEvaluacionRepository objTipoEvaluacionRepository = new TipoEvaluacionRepository();
           // tipselect.ID = Convert.ToInt32(form["Cursoid"]);
           /* foreach (var item in form["TipoEvaluacionIDs"])
            {
                idtipoevaluacion[cont] = Int32.Parse(item);
                cont = cont + 1;

            }*/
            salvado = objTipoEvaluacionRepository.SaveTipoEvaluaciones(form);
           /* tipselect.ItemList = objTipoEvaluacionRepository.GetTipoEvaluacionesSelect();
            if(tipselect.TipoEvaluacionIDs != null)
            {
                List<SelectListItem> selecteditems = tipselect.ItemList.Where(p => tipselect.TipoEvaluacionIDs.Contains(int.Parse(p.Value))).ToList();
                foreach(var selectitem in selecteditems)
                {
                    selectitem.Selected = true;
                   
                }
            }*/
            return RedirectToAction(nameof(IndexCurso));
        }
    }
}
