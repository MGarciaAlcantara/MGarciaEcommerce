using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaController : Controller
    {
        //
        // GET: /Venta/
         [HttpGet]
        public ActionResult ProductoGetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAllEF();
            producto.Productos = result.Objects;
            return View(producto);
        }

         public ActionResult Carrito()
         {
             ML.Result result= new ML.Result();
             result.Objects= new List<object>();
             result.Objects= (List<object>)Session["Carrito"];


             return View(result);
         }

        [HttpGet]
        public ActionResult AddCarrito(int IdProducto)
        {
            if (IdProducto==0)
            {
                
                return RedirectToAction("Carrito");
            }
            bool islist=false;
          

          //  int id = int.Parse(Request["id"]);
            ML.Producto producto = new ML.Producto();
            ML.Result result = new ML.Result();
            ML.Result resultProducto = new ML.Result();
            var pr = producto;
              
              ML.VentaProducto ventaProducto = new ML.VentaProducto();
              if (Session["Carrito"] == null)
              {
                 
                  result.Objects = new List<object>();

                  ventaProducto.Producto = new ML.Producto();
                  resultProducto= BL.Producto.GetByIdEF(IdProducto);
                  if (resultProducto.Correct == true)
                  {
                      ventaProducto.Producto = ((ML.Producto)resultProducto.Object);

                      ventaProducto.Cantidad = 1;

                      result.Objects.Add(ventaProducto);

                      Session["Carrito"] = result.Objects;
                  }

              }
              else
              {
                  int contador = 1;
                  result.Objects = (List<object>)Session["Carrito"];
                 
                  foreach(ML.VentaProducto ventaP in result.Objects){

                      if (IdProducto == ventaP.Producto.IdProducto)
                      {                        
                          islist = true;
                         // contador++;
                      }
                      
                                    
                  }
                  if (islist)
                  {

                      foreach (ML.VentaProducto ventaP in result.Objects)
                      {

                          if (IdProducto == ventaP.Producto.IdProducto)
                          {
                              ventaP.Cantidad++;
                              // contador++;
                          }

                      }


                  }
                  else
                  {
                      resultProducto = BL.Producto.GetByIdEF(IdProducto);
                      if (resultProducto.Correct == true)
                      {
                          ventaProducto.Producto = ((ML.Producto)resultProducto.Object);

                          ventaProducto.Cantidad = 1;

                          result.Objects.Add(ventaProducto);

                          Session["Carrito"] = result.Objects;
                      }
                  }
                

                      Session["Carrito"] = result.Objects;
              
              }


              return RedirectToAction("Carrito");
               
            }

        public ActionResult Incrementar(int IdProducto)
        {
            ML.Result result = new ML.Result();
            result.Objects = (List<object>)Session["Carrito"];

            foreach(ML.VentaProducto ventaProducto in result.Objects){

                if (IdProducto == ventaProducto.Producto.IdProducto)
                {

                    if ( ventaProducto.Cantidad<ventaProducto.Producto.Stock  )
                    {
                        ventaProducto.Cantidad++;
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Stock del producto insuficiente');</script>";
                    }
                }

            
            }

            Session["Carrito"] = result.Objects;

            return RedirectToAction("Carrito");
        }

        public ActionResult Decrementar(int IdProducto)
        {
            ML.Result result = new ML.Result();
            result.Objects = (List<object>)Session["Carrito"];

            foreach (ML.VentaProducto ventaProducto in result.Objects)
            {

                if (IdProducto == ventaProducto.Producto.IdProducto)
                {
                    if (ventaProducto.Cantidad>1)
                    {
                        ventaProducto.Cantidad--;
                    }
                    else
                    {
                       
                    }
                }


            }


            Session["Carrito"] = result.Objects;

            return RedirectToAction("Carrito");
        }
        public ActionResult Delete(int IdProducto)
        {
            
            ML.Result result = new ML.Result();
            result.Objects=(List<object>) Session["Carrito"];

            foreach(ML.VentaProducto ventaProducto in result.Objects){

                if (IdProducto == ventaProducto.Producto.IdProducto)
                {
                   result.Objects.Remove(ventaProducto);
                   break;
              
                }
                else
                {
                  
                }

            }


            Session["Carrito"] = result.Objects;
            return RedirectToAction("Carrito");
        }

        public ActionResult ProcesarVenta()
        {
            decimal Tot = 0;
            ML.Result result = new ML.Result();

            result.Objects = (List<object>)Session["Carrito"];
            ML.Venta venta=new ML.Venta();
           
            foreach (ML.VentaProducto ventaProducto in result.Objects)
            {
                   venta.Total  += ventaProducto.Cantidad * ventaProducto.Producto.Precio;


            }
            venta.Cliente = new ML.Cliente();
            venta.Cliente.IdCliente = 1;
            venta.MetodoPago = new ML.MetodoPago();
            venta.MetodoPago.IdMetodoPago = 1;
            ML.Result resultVenta = new ML.Result();

            resultVenta = BL.Venta.AddEF(venta,result.Objects);

            if (resultVenta.Correct)
            {
                Session.RemoveAll();
                Session.Abandon();
               


            }

            return RedirectToAction("ProductoGetAll");
        }
        }
	}

