using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAll() { 
        
        
         ML.Result result = new ML.Result();
            try { 
            
            using(DL_EF.MGarciaEcommerceEntities context=new DL_EF.MGarciaEcommerceEntities())
            {
                var query = context.AreaGetAll().ToList();
                result.Objects = new List<object>();

                if(query!=null)
                {
                    foreach (var objeto in query)
                    {
                        ML.Area area = new ML.Area();

                        area.IdArea = objeto.IdArea;
                        area.Nombre = objeto.Nombre;
                      

                        result.Objects.Add(area);
                    }
                    result.Correct = true;


                }
            }
            
            }
            catch(Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        
        
        
        }
    }
}
