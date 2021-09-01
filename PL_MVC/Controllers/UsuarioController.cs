using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            
              
                usuario.Nombre = "";                     
                usuario.ApellidoPaterno = "";          
                usuario.ApellidoMaterno = "";


            
            ML.Result result = new ML.Result();
           
            result = BL.Usuario.GetAll(usuario);
          

            usuario.Usuarios = result.Objects;

            return View(usuario);

        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            usuario.Nombre = usuario.Nombre == null ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = usuario.ApellidoPaterno == null ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = usuario.ApellidoMaterno == null ? "" : usuario.ApellidoMaterno;
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll(usuario);
            
            usuario.Usuarios = result.Objects;

            return View(usuario);

        }

        [HttpGet]


        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRoles = BL.Rol.GetAll();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRoles.Objects;
            if (IdUsuario == null)//Add
            {
                return View(usuario);
            }
            else //Update
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                    usuario.Email = ((ML.Usuario)result.Object).Email;
                    usuario.UsuarioPassword = ((ML.Usuario)result.Object).UsuarioPassword;
                    usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                    usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                    usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                    usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                    usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                    usuario.UsuarioStatus = ((ML.Usuario)result.Object).UsuarioStatus;
                    usuario.IdDireccion = ((ML.Usuario)result.Object).IdDireccion;
                    usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;
                    usuario.Telefono = ((ML.Usuario)result.Object).Telefono;

                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }



        }
        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Usuario usuario)
        {
            //     ML.Departamento = new ML.Departamento();
            ML.Result result = new ML.Result();

            //HttpPostedFileBase file = Request.Files["ImagenData"];
            //if (file.ContentLength > 0)
            //{
            //    materia.Imagen = ConvertToBytes(file);
            //}

            if (usuario.IdUsuario == 0)//Add
            {
                result = BL.Usuario.Add(usuario);
                ViewBag.Message = "La materia se agregó correctamente ";
            }
            else //Update
            {

                result = BL.Usuario.Update(usuario);



                ViewBag.Message = "El usuario se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Departamento.DeleteEF(IdUsuario);

            return RedirectToAction("GetAll");
        }

        public ActionResult UpdateStatus(int IdUsuario)
        {

            ML.Result resultUsuario = new ML.Result();
            resultUsuario = BL.Usuario.GetById(IdUsuario);
            ML.Usuario usuario = new ML.Usuario();
            if (resultUsuario.Correct == true)
            {
                usuario = ((ML.Usuario)resultUsuario.Object);

                if (usuario.UsuarioStatus == false)
                {
                    usuario.UsuarioStatus = true;


                }
                else
                {
                    usuario.UsuarioStatus = false;
                }

                ML.Result res = BL.Usuario.Update(usuario);


            }


            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public ActionResult CargaDatos(HttpPostedFileBase archivo)
        {
            ML.Result result = new ML.Result();

            result.Objects = new List<object>();
            using (var reader = new StreamReader(@archivo.InputStream))
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

            return RedirectToAction("GetAll");

        }


    }
}