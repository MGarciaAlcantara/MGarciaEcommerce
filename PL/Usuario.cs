using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PL
{
    public class Usuario
    {


        public static void AddDoc()
        {
            ML.Result result = new ML.Result();

            result.Objects = new List<object>();
            using (var reader = new StreamReader(@"base.txt"))
            {
                ML.Result resultUsuario = new ML.Result();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ML.Usuario usuario = new ML.Usuario();
                    var temp = line.Split();

                    usuario.Email = temp[0];
                    usuario.UsuarioPassword = temp[1];
                    usuario.Nombre = temp[2];
                    usuario.ApellidoPaterno = temp[3];
                    usuario.ApellidoMaterno = temp[4];
                    usuario.FechaNacimiento = DateTime.Parse(temp[5]);
                    usuario.Sexo = temp[6];
                    usuario.UsuarioStatus = Convert.ToBoolean(temp[7]);
                    usuario.IdDireccion = int.Parse(temp[8]);
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.IdRol = int.Parse(temp[9]);
                    usuario.Telefono = temp[10];
                    result.Objects.Add(usuario);
                    resultUsuario = BL.Usuario.Add(usuario);

                }
            }


        }


    }
}
