using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {

        public int IdProducto{set; get;}
        public string Nombre { get; set; }
        public  decimal Precio { get; set; }
        public byte Stock { get; set; }
        public  ML.Proveedor Proveedor  { get; set; }
        public  ML.Departamento Departamento { set; get; }
        public string  Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> Productos{ get; set; }

    }
}
