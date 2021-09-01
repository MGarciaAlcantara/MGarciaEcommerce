using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace PL_MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        //
        // GET: /Departamento/
         [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultDepartamentoAPI = new ML.Result();
            resultDepartamentoAPI.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13192/");

                var responseTask = client.GetAsync("api/departamento");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Departamento resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(resultItem.ToString());
                        resultDepartamentoAPI.Objects.Add(resultItemList);
                    }
                }
            }
            //ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            //var result = Servicio.GetAllDepartamento();
            //  ML.Result result = BL.Departamento.GetAllEF();

             ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = resultDepartamentoAPI.Objects;

            return View(departamento);
        }

         [HttpGet]
        public ActionResult Form(int? IdDepartamento) //Add , Update
        {
            ML.Departamento departamento = new ML.Departamento();
            ML.Result resultAreas = BL.Area.GetAll();
            departamento.Area = new ML.Area();
            departamento.Area.Areas = resultAreas.Objects;

            if (IdDepartamento == null)//Add
            {
                return View(departamento);
            }
            else //Update
            {
              //  ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
             ML.Result result = GetByIdWebAPI(IdDepartamento.Value);


                if (result.Correct)
                {
                    departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
                    departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
                  //  departamento.Area = new ML.Area();
                    departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;
                    departamento.Area.Nombre = ((ML.Departamento)result.Object).Area.Nombre;
                   
                    //materia.Semestre.IdSemestre = ((ML.Materia)result.Object).Semestre.IdSemestre;
                    return View(departamento);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }
         [HttpPost] //Recibir datos del formulario
         public ActionResult Form(ML.Departamento departamento)
         {
             ML.Result result = new ML.Result();
        //     ML.Departamento = new ML.Departamento();
             //ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
             //var result = Servicio.GetAllDepartamento();

             //HttpPostedFileBase file = Request.Files["ImagenData"];
             //if (file.ContentLength > 0)
             //{
             //    materia.Imagen = ConvertToBytes(file);
             //}

             if (departamento.IdDepartamento == 0)//Add
             {
                 //result = Servicio.AddDepartamento(departamento);
                 using (var client = new HttpClient())
                 {
                     client.BaseAddress = new Uri("http://localhost:13192/");
                     //HTTP POST
                     var postTask = client.PostAsJsonAsync<ML.Departamento>("api/departamento", departamento);
                     postTask.Wait();
                     var resultTask = postTask.Result;
                     if (resultTask.IsSuccessStatusCode)
                     {
                         result.Correct = true;
                         return RedirectToAction("GetAll");
                     }
                 }

                 ViewBag.Message = "La materia se agregó correctamente ";
             }
             else //Update
             {
               //  result = Servicio.UpdateDepartamento(departamento);
                 using (var client = new HttpClient())
                 {
                     client.BaseAddress = new Uri("http://localhost:13192/");

                     //HTTP POST
                     var postTask = client.PutAsJsonAsync<ML.Departamento>("api/departamento/"+ departamento.IdDepartamento, departamento);
                     postTask.Wait();

                     var resultTask = postTask.Result;
                     if (resultTask.IsSuccessStatusCode)
                     {
                         result.Correct = true;
                         return RedirectToAction("GetAll");
                     }
                 }

               

                 ViewBag.Message = "La materia se actualizó correctamente ";
             }

             if (!result.Correct)
             {
                 ViewBag.Message = "No se pudo agregar correctamente la materia " + result.ErrorMessage;
             }

             return PartialView("Modal");
         }

         [HttpGet]
         public ActionResult Delete(int IdDepartamento)
         {

             ML.Departamento departamento = new ML.Departamento();
             ML.Result resultListDepartamento = new ML.Result();
             departamento.IdDepartamento = IdDepartamento;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://localhost:13192/");

                 //HTTP POST
                 var postTask = client.DeleteAsync("api/departamento/" + IdDepartamento);
                 postTask.Wait();

                 var result = postTask.Result;
                 if (result.IsSuccessStatusCode)
                 {
                     resultListDepartamento = BL.Producto.GetAllEF();
                     return RedirectToAction("GetAll", resultListDepartamento);
                 }
             }


             resultListDepartamento = BL.Producto.GetAllEF();

             return View("GetAll", resultListDepartamento);
             //ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
             //var result = Servicio.DeleteDepartamento(IdDepartamento);

             //return RedirectToAction("GetAll");
         }


         public JsonResult GetDepartamento(int IdArea) 
         {
             var result = BL.Departamento.GetByIdArea(IdArea);

             List<SelectListItem> opciones = new List<SelectListItem>();

             opciones.Add(new SelectListItem{Text="Selecione una opcion", Value="0" });

             if (result.Object != null)
             {

                 foreach (ML.Departamento departamento in result.Objects)
                 {
                     opciones.Add(new SelectListItem { Text = departamento.Nombre, Value = departamento.IdDepartamento.ToString() });

                 }


             }
             return Json(new SelectList(opciones, "Value", "Text", JsonRequestBehavior.AllowGet));


         }

          public static ML.Result GetByIdWebAPI(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:13192/");
                    var responseTask = client.GetAsync("api/departamento/"+IdDepartamento);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Departamento resultItemList = new ML.Departamento();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Departamento";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    


	}
}