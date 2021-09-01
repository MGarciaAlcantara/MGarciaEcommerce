using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
  public  class Proveedor
    {
        public int IdProveedor { set; get; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }

        public List<object> Proveedores { get; set; }


        
    }
}
