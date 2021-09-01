using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class VentaProducto
    {
        public int IdVentaProducto { set; get; }
        public  ML.Venta Venta { get; set; }
        public int Cantidad { get; set; }
        public ML.Producto Producto { set; get; }



    }
}
