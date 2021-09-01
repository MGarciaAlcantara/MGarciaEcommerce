using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Venta
    {
        public byte IdVenta { set; get; }
        public ML.Cliente Cliente { get; set; }
        public decimal Total { get; set; }

        public ML.MetodoPago MetodoPago{set; get;}

        public DateTime Fecha { get; set; }

    }
}
