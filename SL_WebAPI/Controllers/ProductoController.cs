using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/producto

        [Route("api/producto")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {

            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET api/producto/5
        [Route("api/producto/{IdProducto}")]
        [HttpGet]
        public IHttpActionResult GetByIdEF(int IdProducto)
        {
            ML.Result result = BL.Producto.GetByIdEF(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST api/producto
        [Route("api/producto")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ML.Producto producto)
        {

            ML.Result result = BL.Producto.AddEF(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // PUT api/producto/5
        [Route("api/producto/{IdProducto}")]
        [HttpPut]
        public IHttpActionResult Put(int IdProducto, [FromBody]ML.Producto producto)
        {
            producto.IdProducto = IdProducto;
            ML.Result result = BL.Producto.UpdateEF(producto);
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE api/producto/5
        [Route("api/producto/{IdProducto}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteEF(IdProducto);
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
