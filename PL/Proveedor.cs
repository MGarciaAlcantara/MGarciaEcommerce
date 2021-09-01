using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Proveedor
    {
        public static void GetAllProveedor()
        {
            ML.Result result = BL.Proveedor.GetAll();

            foreach(ML.Proveedor proveedor in result.Objects){
               Console.WriteLine("IdProveedor: "+proveedor.IdProveedor);
                Console.WriteLine("NOMBRE: "+proveedor.Nombre);
                Console.WriteLine("APPATERNO: "+proveedor.ApellidoPaterno);
                Console.WriteLine("APMATERNO: "+proveedor.ApellidoMaterno);
                Console.WriteLine("TELEFONO: "+proveedor.Telefono);



                  Console.WriteLine();
            
            }

            if(result.Correct==true)
            {
                Console.WriteLine("PROVEEDORES");

            }
            else
            {
                Console.WriteLine("No hay proveedores");
            }

        }

    }
}
