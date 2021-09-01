using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpPost]
        public ActionResult Login(ML.Usuario usuario){
   
            //ML.Result result = new ML.Result();
            //try
            //{
            //    string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri("http://localhost:13192/");
            //        var responseTask = client.PostAsJsonAsync<ML.Usuario>("api/Login",usuario);
            //        responseTask.Wait();
            //        var resultAPI = responseTask.Result;
            //        if (resultAPI.IsSuccessStatusCode)
            //        {
            //            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
            //            readTask.Wait();
            //            ML.Usuario resultItemList = new ML.Usuario();
            //            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
            //            result.Object = resultItemList;

            //            result.Correct = true;
            //            using (var clientToken = new HttpClient())
            //            {
            //               // client.BaseAddress = new Uri("http://localhost:13192/");
            //                var responseTaskToken = client.PostAsJsonAsync<ML.Usuario>("api/Login/Autenticar", usuario);
            //                responseTask.Wait();
            //                var resultAPIToken = responseTask.Result;
            //                string token = responseTaskToken.Result.ToString();
            //                if (resultAPIToken.IsSuccessStatusCode)
            //                {
            //                    return RedirectToAction("Index", "Home");
            //                }
            //                else
            //                {
            //                    result.Correct = false;
            //                    result.ErrorMessage = "No existen registros en la tabla Departamento";
            //                }

            //            }

            //        }
            //        else
            //        {
            //            result.Correct = false;
            //            result.ErrorMessage = "No existen registros en la tabla Departamento";
            //        }

            //    }

            //}

            //catch (Exception ex)
            //{
            //    result.Correct = false;
            //    result.ErrorMessage = ex.Message;

            //}

            //usuario = ((ML.Usuario)result.Object);



            //if (result.Correct)
            //{
            //    if (usuario.Rol.Nombre == "Administrador")
            //    {
            //        Session["TipoUsuario"] = "Administrador";
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else if (usuario.Rol.Nombre == "Cliente")
            //    {
            //        Session["TipoUsuario"] = "Cliente";
            //         return RedirectToAction("Index", "Home");
            //    }
          


            //}

            //return View();
              
            ML.Result result = new ML.Result();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:13192/");
               

                var postTask = client.PostAsJsonAsync<ML.Usuario>("api/Login", usuario);
                postTask.Wait();

                var resultApi = postTask.Result;
                if (resultApi.IsSuccessStatusCode) //usuario si existe
                {
                    var stream = resultApi.Content;

                    var readTask = resultApi.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();


                    using(var clientToken= new HttpClient())
                    {
                        clientToken.BaseAddress = new Uri("http://localhost:13192/");

                        var postTaskToken = clientToken.PostAsJsonAsync<ML.Usuario>("api/Login/Autenticar", usuario);
                        postTaskToken.Wait();
                        var resultApiToken = postTaskToken.Result;


                        if(resultApiToken.IsSuccessStatusCode)
                        {
                            var readTaskAPI = resultApiToken.Content.ReadAsAsync<ML.Result>();
                            readTaskAPI.Wait();

                            usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTaskAPI.Result.Object.ToString());
                            Session["UsuarioSession"] = usuario;

                            return RedirectToAction("Index", "Home");

                        }
                        else
                        {
                            var readTaskAPI = resultApiToken.Content.ReadAsAsync<ML.Result>();
                            readTaskAPI.Wait();

                            
                            ViewBag.Message = readTaskAPI.Result.ErrorMessage;
                            ViewData["msg"] = readTaskAPI.Result.ErrorMessage;
                             TempData["msg"] = "<script>alert(Usuario o contraseña incorrectos');</script>";
                        }

                    }
                }
                else
                {
                    ViewBag.Message = "El email ingresado no está registrado";
                }
                return PartialView("Login");

            }
        }


        
        [HttpGet]
        public ActionResult Login()
        {
            ML.Usuario login = new ML.Usuario();
            return View();
        }
	}
}