using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultProductoAPI = new ML.Result();
            resultProductoAPI.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13192/");

                var responseTask = client.GetAsync("api/producto");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        resultProductoAPI.Objects.Add(resultItemList);
                    }
                }
            }

            //ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            //var result = Servicio.GetAllProducto();
          //  ML.Result result = BL.Producto.GetAllEF();

            ML.Producto producto = new ML.Producto();
            producto.Productos = resultProductoAPI.Objects;

            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto) //Add , Update
        {
            ML.Producto producto = new ML.Producto();

            ML.Result resultProveedores = BL.Proveedor.GetAll();
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.Proveedores = resultProveedores.Objects;

            ML.Result resultDepartamentos = BL.Departamento.GetAllEF();
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Departamentos = resultDepartamentos.Objects;

            ML.Result resultAreas = BL.Area.GetAll();
            producto.Departamento.Area = new ML.Area();
            producto.Departamento.Area.Areas = resultAreas.Objects;
          
            if (IdProducto == null)//Add
            {
                return View(producto);
            }
            else //Update
            {
               // ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
               //var result = Servicio.GetByIdProducto(IdProducto.Value);
                ML.Result result = GetByIdWebAPI(IdProducto.Value);

                if (result.Correct)
                {
                    producto.IdProducto= ((ML.Producto)result.Object).IdProducto;
                    producto.Nombre = ((ML.Producto)result.Object).Nombre;
                    producto.Precio = ((ML.Producto)result.Object).Precio;
                    producto.Stock = ((ML.Producto)result.Object).Stock;
                   
                    producto.Proveedor.IdProveedor= ((ML.Producto)result.Object).Proveedor.IdProveedor;
                    producto.Proveedor.Nombre= ((ML.Producto)result.Object).Proveedor.Nombre;

                    producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                    producto.Departamento.Nombre = ((ML.Producto)result.Object).Departamento.Nombre;

                    producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                    producto.Departamento.Area.Nombre = ((ML.Producto)result.Object).Departamento.Area.Nombre;

               
                   
                    producto.Descripcion= ((ML.Producto)result.Object).Descripcion;
                    producto.Imagen = ((ML.Producto)result.Object).Imagen;


                    return View(producto);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }
        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Producto producto)
        {
            ML.Producto productoImage = new ML.Producto();
           // ML.Result result = new ML.Result();
            ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            var result=Servicio.GetAllProducto();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }

            if (producto.IdProducto == 0)//Add
            {            
               // result = Servicio.AddProducto(producto);
              //  result = BL.Producto.AddEF(producto);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:13192/");
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Producto>("api/producto", producto);
                    postTask.Wait();
                    var resultTask = postTask.Result;
                    if (resultTask.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                        return RedirectToAction("GetAll");
                    }
                }
                ViewBag.Message = "El producto se agregó correctamente ";
            }
            else //Update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:13192/");
                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ML.Producto>("api/producto/" + producto.IdProducto, producto);
                    postTask.Wait();
                    var resultTask = postTask.Result;
                    if (resultTask.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                        return RedirectToAction("GetAll");
                    }
                }
                //result = Servicio.UpdateProducto(producto);

              //  result = BL.Producto.UpdateEF(producto);



                ViewBag.Message = "El producto se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el producto" + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result resultListProduct = new ML.Result();
            producto.IdProducto=IdProducto;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13192/");

                //HTTP POST
                var postTask = client.DeleteAsync("api/producto/" +IdProducto);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultListProduct = BL.Producto.GetAllEF();
                    return RedirectToAction("GetAll", resultListProduct);
                }
            }


            resultListProduct = BL.Producto.GetAllEF();

            return View("GetAll", resultListProduct);
 

            //ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            //var result = Servicio.DeleteProducto(IdProducto);

            //return RedirectToAction("GetAll");
        }

        [HttpPost]
        public JsonResult GetDepartamento(int IdArea)
        {
            var result = BL.Departamento.GetByIdArea(IdArea);

            List<SelectListItem> opciones = new List<SelectListItem>();

            opciones.Add(new SelectListItem { Text = "Selecione una opcion", Value = "0" });

            if (result.Objects != null)
            {

                foreach (ML.Departamento departamento in result.Objects)
                {
                    opciones.Add(new SelectListItem { Text = departamento.Nombre, Value = departamento.IdDepartamento.ToString() });

                }


            }
            return Json(new SelectList(opciones, "Value", "Text", JsonRequestBehavior.AllowGet));


        }
      public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
       {
        byte[] data = null;
          System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
           data = reader.ReadBytes((int)Imagen.ContentLength);

        return data;
    }
          public static ML.Result GetByIdWebAPI(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:13192/");
                    var responseTask = client.GetAsync("api/producto/"+IdProducto);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Producto resultItemList = new ML.Producto();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Producto";
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
