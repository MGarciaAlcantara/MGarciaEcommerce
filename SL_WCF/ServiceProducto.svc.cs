using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProducto : IServiceProducto
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string Saludo(string Nombre)
        {

            return "HOLA " + Nombre;

        }
        public Result AddProducto(ML.Producto producto)
        {

            ML.Result result = BL.Producto.AddEF(producto);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }

        public Result UpdateProducto(ML.Producto producto)
        {

            ML.Result result = BL.Producto.UpdateEF(producto);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }
        public Result DeleteProducto(int IdProducto)
        {

            ML.Result result = BL.Producto.DeleteEF(IdProducto);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }
        public Result GetAllProducto()
        {

            ML.Result result = BL.Producto.GetAllEF();

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex , Objects=result.Objects };

        }
        public Result GetByIdProducto(int IdProducto)
        {

            ML.Result result = BL.Producto.GetByIdEF(IdProducto);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object };

        }
       
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
