using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;


namespace SL_WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/login
        [HttpPost]
        [Route("api/Login")]
        public IHttpActionResult GetByUsername([FromBody] ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.GetByEmail(usuario);

            if (result.Correct)
            {

                return Ok(result);
            }
            else
                {

                return Content(HttpStatusCode.NotFound, result);
                }
            }

        [HttpPost]
        [Route("api/Login/Autenticar")]
        public IHttpActionResult Autenticar([FromBody] ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.GetByEmail(usuario);
            ML.Usuario usuarioItem = new ML.Usuario();
          
            usuarioItem=((ML.Usuario)result.Object);
            if (result.Correct)
            {
                if (usuario.Email == usuarioItem.Email)
                {
                    if (usuario.UsuarioPassword == usuarioItem.UsuarioPassword)
                    {
                        usuarioItem.Token = GenerateTokenJwt(usuario);
                        result.Correct = true;
                        result.Object = usuarioItem;
                        return Ok(result);

                    
                    }
                    else
                    
                     {
                         result.Correct = false; 
                        result.ErrorMessage = "Contraseña incorrecta";
                         return Content(HttpStatusCode.NotFound, result);
            

                    }
                }
                else
                {
                    result.Correct = false; 
                    result.ErrorMessage = "Usuario Incorrecto";
                     return Content(HttpStatusCode.NotFound, result);
            
                }                           
              
            }
            else
            {
                result.Correct = false; 
                result.ErrorMessage = "Usuario no existente";
                return Content(HttpStatusCode.NotFound, result);
            }
        }




        public static string GenerateTokenJwt(ML.Usuario usuario)
        {
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.Email) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
