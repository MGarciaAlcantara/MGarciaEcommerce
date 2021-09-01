using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {

          //  Console.WriteLine("INSERT EN BASE DE DATOS SQL-SERVER");
           // PL.Producto.Menu();

            PL.Departamento.Menu();
         //   PL.Area.GetAll();
            //PL.Proveedor.GetAllProveedor();
            //PL.Usuario.AddDoc();
          //   PL.Venta.AddCompra();
           // PL.Producto.GetById();
       
           


         //  PL.VentaProducto.Add();


            SL_WCF.ServiceProducto Servicio = new SL_WCF.ServiceProducto();
          
            Console.WriteLine(Servicio.Saludo("Miguel"));
            ServiceReferenceDepartamento.ServiceDepartamentoClient s = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
         
            Console.ReadKey();
        }

    }
}
