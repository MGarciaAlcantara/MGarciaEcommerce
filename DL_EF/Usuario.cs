//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string UsuarioPassword { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public Nullable<bool> UsuarioStatus { get; set; }
        public Nullable<int> IdDireccion { get; set; }
        public Nullable<int> IdRol { get; set; }
        public string Telefono { get; set; }
    
        public virtual Rol Rol { get; set; }
    }
}
