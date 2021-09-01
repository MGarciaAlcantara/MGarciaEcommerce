using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Area
    {
        public static void GetAll() {


            ML.Result result = new ML.Result();
            result = BL.Area.GetAll();

            foreach(ML.Area area in result.Objects)
            {
                Console.WriteLine("Id Del area es: " + area.IdArea);
                Console.WriteLine("Nombre del area " + area.Nombre);
                Console.WriteLine("----------------------------");


            
            }
          
        
        
        
        
        }

    }
}
