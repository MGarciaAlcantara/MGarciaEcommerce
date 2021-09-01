using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
   public class Departamento
    {

       public static void GetAll() {
           ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
           //   ML.Result result = BL.Departamento.GetAllLINQ();
               var result= Servicio.GetAllDepartamento();
           foreach (ML.Departamento departamento in result.Objects) {

               Console.WriteLine("Id del departamento: " + departamento.IdDepartamento);
               Console.WriteLine("INombre del departamento: " + departamento.Nombre);
               Console.WriteLine("Id del area: " + departamento.Area.IdArea);
               Console.WriteLine("");
           }

       

       
       
       }
        public static void Add() {

            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Inserta el nombre del departamento");
            departamento.Nombre = Console.ReadLine();
            Console.WriteLine("Inserta el Id del Area");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());


            ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            var result = Servicio.AddDepartamento(departamento);
          

            if (result.Correct)
            {
                Console.WriteLine("El producto se registró correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el departamento" + result.ErrorMessage);
            }


        
        }
        public static void Update() { 
        
         ML.Departamento departamento=new ML.Departamento();
          Console.WriteLine("Ingresa el ID del departammento a editar");
          departamento.IdDepartamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nuevo nombre del departamento");
            departamento.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo ID de area");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine()); ;

            ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            var result = Servicio.UpdateDepartamento(departamento);
          
         


            if (result.Correct)
            {

                Console.WriteLine("Exito ebn la actualizacion");


            }
            else { Console.WriteLine("error en la modificacion "+result.ErrorMessage); }
        
        }
        public static void Delete()
        {
            ML.Departamento departemento = new ML.Departamento();
            Console.WriteLine("Inserta el ID del producto a eliminar");

            departemento.IdDepartamento = int.Parse(Console.ReadLine());

            ServiceReferenceDepartamento.ServiceDepartamentoClient Servicio = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            var result = Servicio.DeleteDepartamento(departemento.IdDepartamento);
          

            if (result.Correct)
            {
                Console.WriteLine("Se elimino correctamente ");
            }
            else
            {
                Console.WriteLine("Error al eliminar producto"+ result.ErrorMessage);
            }
        }
        public static void Menu(){ int Opcion=0;
          
            Console.WriteLine("Selecciona la accion a realizar");
            Console.WriteLine("1. Insertar Departamento");
            Console.WriteLine("2. Actualizar Departamento");
            Console.WriteLine("3. Eliminar Departamento");
            Console.WriteLine("4. Mostrar registros");

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
