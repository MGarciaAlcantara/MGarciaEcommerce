using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Usuario
    {
       public static ML.Result Add(ML.Usuario usuario)
       {

           ML.Result result = new ML.Result();


           try
           {
               using(DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities()){

                   var query = Convert.ToString(context.UsuarioAdd(usuario.Email, usuario.UsuarioPassword, usuario.Nombre, usuario.ApellidoPaterno,
                       usuario.ApellidoMaterno, usuario.FechaNacimiento.ToShortDateString(), usuario.Sexo, usuario.UsuarioStatus, usuario.IdDireccion,
                       usuario.Rol.IdRol, usuario.Telefono).FirstOrDefault());

                   if (query =="Usuario Insertado")
                   {
                       result.Correct = true;
                   }
                   else
                   {
                       if (query.Length >= 49 && query.Substring(0, 50) == "Violation of UNIQUE KEY constraint 'uniqueNombre'.")
                       {
                           result.Correct = false;
                           result.ErrorMessage = "Ya existe un usuario  registrado con esos datos";
                       }
                       else
                       {
                           result.Correct = false;
                           result.ErrorMessage = query;
                       }
                       
                       
                   }
               }


           }
           catch(Exception ex){
                             
              result.Correct = false;
               result.ErrorMessage = ex.Message;
           }

           return result;
       }

       public static ML.Result Update(ML.Usuario usuario)
       {
           ML.Result result = new ML.Result();

           try
           {
               using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
               {

                   var query = Convert.ToString(context.UsuarioUpdate(usuario.IdUsuario, usuario.Email, usuario.UsuarioPassword, usuario.Nombre, usuario.ApellidoPaterno,
                       usuario.ApellidoMaterno, usuario.FechaNacimiento.ToShortDateString(), usuario.Sexo, usuario.UsuarioStatus, usuario.IdDireccion,
                       usuario.Rol.IdRol, usuario.Telefono).FirstOrDefault());

                   if (query == "Usuario Insertado")
                   {
                       result.Correct = true;
                   }
                   else
                   {
                       if (query.Length >= 49 && query.Substring(0, 50) == "Violation of UNIQUE KEY constraint 'uniqueNombre'.")
                       {
                           result.Correct = false;
                           result.ErrorMessage = "Ya existe un usuario  registrado con esos datos";
                       }
                       else
                       {
                           result.Correct = false;
                           result.ErrorMessage = query;
                       }
                   }


               }
           }
           catch (Exception ex)
           {

               result.Correct = false;
               result.ErrorMessage = ex.Message;
           }

           return result;

       }

       public static ML.Result Delete(ML.Usuario usuario)
       {

           ML.Result result = new ML.Result();


           try
           {
               using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
               {

                   var query = context.UsuarioDelete(usuario.IdUsuario);
                      

                   if (query > 0)
                   {
                       result.Correct = true;
                   }
                   else
                   {
                       result.Correct = false;
                       result.ErrorMessage = "Error al eliminar usuario";

                   }
               }


           }
           catch (Exception ex)
           {

               result.Correct = false;
               result.ErrorMessage = ex.Message;
           }

           return result;



       }

       public static ML.Result GetAll(ML.Usuario UsuarioItem)
       {
           ML.Result result = new ML.Result();

           try
           {

               using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
               {
                   var query = context.UsuarioGetAllTest(UsuarioItem.Nombre,UsuarioItem.ApellidoPaterno,UsuarioItem.ApellidoMaterno).ToList();

                   if (query != null)
                   {
                       result.Objects = new List<object>();
                       foreach (var objeto in query)
                       {
                           ML.Usuario usuario = new ML.Usuario();
                           usuario.IdUsuario = objeto.IdUsuario;
                           usuario.Email = objeto.Email;
                           usuario.UsuarioPassword=objeto.UsuarioPassword;
                           usuario.Nombre = objeto.NombreUsuario;
                           usuario.ApellidoPaterno = objeto.ApellidoPaterno;
                           usuario.ApellidoMaterno = objeto.ApellidoMaterno;
                           usuario.FechaNacimiento = objeto.FechaNacimiento.Value;
                           usuario.Sexo = objeto.Sexo;
                           usuario.UsuarioStatus = objeto.UsuarioStatus.Value;
                           usuario.IdDireccion = objeto.IdDireccion.Value;
                           usuario.Rol = new ML.Rol();
                           usuario.Rol.IdRol = objeto.IdRol;
                           usuario.Rol.Nombre = objeto.RolNombre;
                           usuario.Telefono = objeto.Telefono;

                           result.Objects.Add(usuario);
                       }

                       result.Correct=true;

                   }
                   else
                   {
                       result.Correct = false;
                       result.ErrorMessage = "NO hay registros en la tabla usuario";

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

       public static ML.Result GetById(int IdUsuario)
       {
           ML.Result result = new ML.Result();

           try
           {

               using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
               {
                   var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                   if (query != null)
                   {
                      
                           ML.Usuario usuario = new ML.Usuario();
                           usuario.IdUsuario = IdUsuario;
                           usuario.Email = query.Email;
                           usuario.UsuarioPassword =query.UsuarioPassword;
                           usuario.Nombre = query.NombreUsuario;
                           usuario.ApellidoPaterno = query.ApellidoPaterno;
                           usuario.ApellidoMaterno = query.ApellidoMaterno;
                           usuario.FechaNacimiento = query.FechaNacimiento.Value;
                           usuario.Sexo = query.Sexo;
                           usuario.UsuarioStatus = query.UsuarioStatus.Value;
                           usuario.IdDireccion = query.IdDireccion.Value;
                           usuario.Rol = new ML.Rol();
                           usuario.Rol.IdRol = query.IdRol;
                           usuario.Rol.Nombre = query.RolNombre;
                           usuario.Telefono = query.Telefono;

                           result.Object = usuario;
                       

                       result.Correct = true;

                   }
                   else
                   {
                       result.Correct = false;
                       result.ErrorMessage = "NO hay registros en la tabla usuario";

                   }


               }



           }
           catch (Exception ex)
           {
               result.Correct = false;
               result.ErrorMessage = ex.Message;
           }

           return result;


       }

       public static ML.Result GetByEmail(ML.Usuario usuarioItem)
       {

           ML.Result result = new ML.Result();

           try
           {
               using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
               {

                   var query = context.UsuarioGetByEmail(usuarioItem.Email).FirstOrDefault();

                   if (query != null)
                   {
                       ML.Usuario usuario = new ML.Usuario();
                      
                           usuario.Rol = new ML.Rol();
                           usuario.Rol.IdRol = query.IdRol.Value;
                           usuario.Rol.Nombre = query.NombreRol;
                           usuario.Nombre = query.NombreUsuario;
                           usuario.ApellidoPaterno = query.ApellidoPaterno;
                           usuario.ApellidoMaterno = query.ApellidoMaterno;
                           usuario.Sexo = query.Sexo;
                           usuario.Email = query.Email;
                           usuario.UsuarioPassword = query.UsuarioPassword;
                           usuario.FechaNacimiento = query.FechaNacimiento.Value;

                           result.Object = usuario;
                           result.Correct = true;

                       

                   }
                   else {
                       result.Correct = false;

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
