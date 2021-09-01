using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
  public  class Usuario
    {

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string UsuarioPassword { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Token { get; set; }
        public bool UsuarioStatus { get; set; }
        public int IdDireccion { get; set; }
        public ML.Rol Rol { get; set; }
        public string Telefono { get; set; }
        public List<object> Usuarios { get; set; }

 


    }
}
