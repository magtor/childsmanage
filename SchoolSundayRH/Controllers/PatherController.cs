using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSundayRH.Models;
using SchoolSundayRH.Repository;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace SchoolSundayRH.Controllers
{
    public class PatherController : Controller
    {

        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        private readonly IWebHostEnvironment _host;
        // GET: PatherController
        

        public PatherController(IWebHostEnvironment host)
        {
            _host = host;
        }

        [HttpGet]
        public ActionResult ImprimirPdf(uint padreid)
        {
             List<Padres> lstpathers = null;
             string nombrepadre1 = "";
             string nombrepadre2 = "";
            string apellidopadre1 = "";
             uint idtpadre;
             PatherRepository objPatherRepositoy = new PatherRepository();
             lstpathers = objPatherRepositoy.GetDataPadre(1);
             foreach(var itempadre in lstpathers)
             {
                 nombrepadre1 = itempadre.Nombre1;
                nombrepadre2 = itempadre.Nombre2;
                apellidopadre1 = itempadre.Apellido1;
                 idtpadre = itempadre.Padreid;
             }

             List<Childs> lsthijos = null;
            lsthijos = objPatherRepositoy.GetListSonFromPather1(1);




            var data = Document.Create(docu =>
            {
                docu.Page(pagina =>
                {
                    pagina.Margin(30);
                    pagina.Header().ShowOnce().Row(fila =>
                    {
                        var rutaimagen = System.IO.Path.Combine(_host.WebRootPath, "images/arcodorado.jpg");
                        byte[] imageData = System.IO.File.ReadAllBytes(rutaimagen);
                        fila.ConstantItem(150).Image(imageData);

                        fila.RelativeItem().Column(col =>
                        {
                            col.Item().AlignCenter().Text("Colegio Politecnico La Rueca").Bold().FontSize(14);
                            col.Item().AlignCenter().Text(nombrepadre1.ToString()+" "+nombrepadre2.ToString()
                                +" " +apellidopadre1.ToString()).FontSize(9);
                            col.Item().AlignCenter().Text("987 987 123 / 02 213232").FontSize(9);
                            col.Item().AlignCenter().Text("codigo@example.com").FontSize(9);

                        });

                        fila.RelativeItem().Column(col =>
                        {
                            col.Item().Border(1).BorderColor("#257272")
                            .AlignCenter().Text("RUC 21312312312");

                            col.Item().Background("#257272").Border(1)
                            .BorderColor("#257272").AlignCenter()
                            .Text("Boleta de venta").FontColor("#fff");

                            col.Item().Border(1).BorderColor("#257272").
                            AlignCenter().Text("B0001 - 234");


                        });
                    });
                    pagina.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().Column(col2 =>
                        {
                            col2.Item().Text("Datos del cliente").Underline().Bold();

                            col2.Item().Text(txt =>
                            {
                                txt.Span("Nombre: ").SemiBold().FontSize(10);
                                txt.Span("Mario mendoza").FontSize(10);
                            });

                            col2.Item().Text(txt =>
                            {
                                txt.Span("DNI: ").SemiBold().FontSize(10);
                                txt.Span("978978979").FontSize(10);
                            });

                            col2.Item().Text(txt =>
                            {
                                txt.Span("Direccion: ").SemiBold().FontSize(10);
                                txt.Span("av. miraflores 123").FontSize(10);
                            });
                        });

                        col1.Item().LineHorizontal(0.5f);

                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(5);
                                columns.RelativeColumn();//Primer Nombre
                                columns.RelativeColumn();//Segundo Nombre
                                columns.RelativeColumn();//Primer Apellido
                                columns.RelativeColumn();//Segundo Apellido
                                columns.RelativeColumn();//fotografia
                            });

                            tabla.Header(header =>
                            {
                                header.Cell().Background("#257272")
                                .Padding(2).Text("P.Nombre").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("S.Nombre").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("P.Apellido").FontColor("#fff");

                                header.Cell().Background("#257272")
                                .Padding(2).Text("S.Apellido").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("Foto").FontColor("#fff");
                            });

                            foreach (var item in lsthijos)
                            {
                                /*var cantidad = Placeholders.Random.Next(1, 10);
                                var precio = Placeholders.Random.Next(5, 15);
                                var total = cantidad * precio;
                                var rutaimagen = System.IO.Path.Combine(_host.WebRootPath, "images/salmo27.jpg");
                                byte[] imageData = System.IO.File.ReadAllBytes(rutaimagen);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).Text(Placeholders.Label()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(2).Text(cantidad.ToString()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(2).Text($"S/. {precio}").FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                        .Padding(2).AlignRight().Image(imageData);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(2).AlignRight().Text($"S/. {total}").FontSize(10);*/
                                var rutaimagen = System.IO.Path.Combine(_host.WebRootPath, "images/"+item.Photo);
                                byte[] imageData = System.IO.File.ReadAllBytes(rutaimagen);
                                var total = 12 * 12;

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(2).Text(item.Nombre1.ToString()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(2).Text(item.Nombre2.ToString()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                              .Padding(2).Text(item.Apellido1.ToString()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(2).Text(item.Apellido2.ToString()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignRight().Image(imageData);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                       .Padding(2).AlignRight().Text($"S/. {total}").FontSize(10);
                            }

                        });

                        //col1.Item().AlignRight().Text("Total: 1500").FontSize(12);

                        if (1 == 1)
                            col1.Item().Background(Colors.Grey.Lighten3).Padding(10)
                            .Column(column =>
                            {
                                column.Item().Text("Comentarios").FontSize(14);
                                column.Item().Text(Placeholders.LoremIpsum());
                                column.Spacing(5);
                            });

                        col1.Spacing(10);
                    });


                    pagina.Footer()
                    .AlignRight()
                    .Text(txt =>
                    {
                        txt.Span("Pagina ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" de ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });


            }).GeneratePdf();

            System.IO.Stream stream = new System.IO.MemoryStream(data);
            return File(stream, "application/pdf", "detalleventa.pdf");
        }

        [HttpGet]
        [Route("IndexPather")]
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
