using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Producto
    {
        public static void GetAll(){


            ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();

            var result = Servicio.GetAllProducto();

        foreach(ML.Producto producto in result.Objects){

            Console.WriteLine("Id del producto: " + producto.IdProducto);
            Console.WriteLine("Nombre del producto: " + producto.Nombre);
            Console.WriteLine("Precio del producto: " + producto.Precio);
            Console.WriteLine("Stock del producto: " + producto.Stock);
            Console.WriteLine("Id del Proveedor: " + producto.Proveedor.IdProveedor );
            Console.WriteLine("Id del Departamento: " + producto.Departamento.IdDepartamento);
            Console.WriteLine("Descripcion del producto: " + producto.Descripcion);
            Console.WriteLine("");
        
        }         
                 
        }
        public static void GetById()
        {
               
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingresa ID");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            var result = Servicio.GetByIdProducto(producto.IdProducto);

            Console.WriteLine("Nombre del producto: " + ((ML.Producto)result.Object).Nombre);
            Console.WriteLine("Precio del producto: " + ((ML.Producto)result.Object).Precio);
            Console.WriteLine("Stock del producto: " + ((ML.Producto)result.Object).Stock);
            Console.WriteLine("Id del Proveedor: " + ((ML.Producto)result.Object).Proveedor.IdProveedor);
            Console.WriteLine("Id del Departamento: " + ((ML.Producto)result.Object).Departamento.IdDepartamento);
            Console.WriteLine("Descripcion del producto: " + ((ML.Producto)result.Object).Descripcion);

                Console.WriteLine("");
        }
         
        public static void Add() {

            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio del producto");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock disponible del producto");
            producto.Stock = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Id del proveedor ");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor= int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Id deldepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion del producto ");
            producto.Descripcion = Console.ReadLine();



            ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            var result = Servicio.AddProducto(producto);

            if (result.Correct)
            {
                Console.WriteLine("El producto se registró correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el producto" + result.ErrorMessage);
            }
        
        }

        public static void Update() {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el ID del producto que quieres actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());


            Console.WriteLine("Ingresa el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio del producto");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock disponible del producto");
            producto.Stock = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Id del proveedor ");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Id deldepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion del producto ");
            producto.Descripcion = Console.ReadLine();


            ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            var result = Servicio.UpdateProducto(producto);
           

            if (result.Correct)
            {
                Console.WriteLine("El producto se registró correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el producto" + result.ErrorMessage);
            }
        
        
        
        }
        public static void Delete() {

            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Inserta el ID del producto que deseas eliminar");
            producto.IdProducto= int.Parse(Console.ReadLine());


            ServiceReferenceProducto.ServiceProductoClient Servicio = new ServiceReferenceProducto.ServiceProductoClient();
            var result = Servicio.DeleteProducto(producto.IdProducto);

            if (result.Correct)
            {
                Console.WriteLine("El producto se elimino correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar el producto" + result.ErrorMessage);
            }
        
        
        }

        public static void Menu() {
            int Opcion=0;
          
            Console.WriteLine("Selecciona la accion a realizar");
            Console.WriteLine("1. Insertar Producto");
            Console.WriteLine("2. Actualizar Producto");
            Console.WriteLine("3. Eliminar producto");
            Console.WriteLine("4. Ver registros");

            Opcion = int.Parse(Console.ReadLine());

            switch (Opcion) { 
            
                case 1:
                    Add();
                    break;
                case 2:
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    GetAll();
                    break;


            
            }

        
        }
    }
}
