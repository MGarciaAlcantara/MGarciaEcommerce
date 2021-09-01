using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Venta
    {
        public static void AddSP() { 
        ML.Venta venta=new ML.Venta();

        Console.WriteLine ("Ingresa el ID del cliente");
     
        venta.Cliente = new ML.Cliente();
        venta.Cliente.IdCliente = int.Parse(Console.ReadLine());
        Console.WriteLine("ingresa el total de la venta");
        venta.Total = decimal.Parse(Console.ReadLine());
        Console.WriteLine("ingresa el metodo de pago");
        venta.MetodoPago = new ML.MetodoPago();
        venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());

       ML.Result result =new ML.Result();
           BL.Venta.AddEF(venta,result.Objects);

        if (result.Correct)
        {
            Console.WriteLine("El producto se registró correctamente");
        }
        else
        {
            Console.WriteLine("Ocurrió un error al insertar el departamento" + result.ErrorMessage);
        }

        }

        public static void AddCompra()
        {
              ML.Result result = new ML.Result();
              ML.Venta venta=new ML.Venta();
              result.Objects = new List<object>();
            int Compra = 0;
            
            int Rango;

            Console.WriteLine("¡BIENVENIDO!");
            Console.WriteLine("1.Realizar Compra");
            Console.WriteLine("2.Salir");
            Compra=int.Parse(Console.ReadLine());
            if(Compra==1)
            {
                Console.WriteLine("----------------------------------PRODUCTOS DISPONIBLES------------------------------");
                PL.Producto.GetAll();

            }
         
            while (Compra == 1)
            {
                Console.WriteLine("Ingresa tu ID de cliente");
                venta.Cliente  = new ML.Cliente();
                venta.Cliente.IdCliente = int.Parse(Console.ReadLine());
                Console.WriteLine("Elige metodo de pago");
                Console.WriteLine("1. Efectivo");
                Console.WriteLine("2. Tarjeta");
                venta.MetodoPago = new ML.MetodoPago();
                venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());
              
                ML.VentaProducto ventaProducto=new ML.VentaProducto();
           
                Console.WriteLine("Inserta ID del producto que desees");
                ventaProducto.Producto = new ML.Producto();
                ventaProducto.Producto.IdProducto= int.Parse(Console.ReadLine());
             
                Console.WriteLine("Inserta Cantidad");
                ventaProducto.Cantidad= int.Parse(Console.ReadLine());

               result.Objects.Add(ventaProducto);

               ML.Result resultProducto = BL.Producto.GetById(ventaProducto.Producto.IdProducto);

                decimal SubTotal=ventaProducto.Cantidad*((ML.Producto)resultProducto.Object).Precio;
                venta.Total+=SubTotal;

                Console.WriteLine("Desea Agregar otro producto");
                Console.WriteLine("1. SI");
                Console.WriteLine("2. NO");
                Compra = int.Parse(Console.ReadLine());

            }


          
            BL.Venta.AddEF(venta,result.Objects);           
            Rango=result.Objects.Count();

            for (int i=0; i < Rango; i++) {

                Console.WriteLine(" ID Producto agregado: "+ result.Objects[i]);
            }

                Console.WriteLine("¡GRACIAS POR SU PREFERENCIA!");
    }
}

}
