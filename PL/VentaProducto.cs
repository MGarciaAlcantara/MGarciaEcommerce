using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
   public class VentaProducto
    {
       public static void Add() {

           ML.VentaProducto ventaProducto = new ML.VentaProducto();
           Console.WriteLine("Inserta el ID de la venta");
           ventaProducto.Venta = new ML.Venta();
           ventaProducto.Venta.IdVenta = byte.Parse(Console.ReadLine());
           Console.WriteLine("Inserta la cantidad de la venta");
           ventaProducto.Cantidad = int.Parse(Console.ReadLine());
           Console.WriteLine("Inserta el ID del Producto");
           ventaProducto.Producto = new ML.Producto();
           ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

           ML.Result result = BL.VentaProducto.AddEF(ventaProducto);

           if (result.Correct)
           {
               Console.WriteLine("El producto se registró correctamente");
           }
           else
           {
               Console.WriteLine("Ocurrió un error al insertar el departamento" + result.ErrorMessage);
           }
       
       
       }
    }
}
