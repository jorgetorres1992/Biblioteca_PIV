using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Http.Description;// habilita la funcion responsetype

namespace Biblioteca.Host.Controllers
{
    public class EditorialController : ApiController
    {

        BibliotecaContext bibiotecaContext = new BibliotecaContext("BibliotecaMaestro");
        // se llama al connectionstring del web.config

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibiotecaContext.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: api/Editorial
        public IEnumerable<Editorial> Get()
        {
            return bibiotecaContext.Editoriales;
        }

        // GET: api/Editorial/5
        [ResponseType(typeof(Editorial))]// responsetype idica a asp que tipo es la respuesta que va devolver
        public IHttpActionResult Get(int id)
        {
            var editorial= bibiotecaContext.Editoriales.Find(id);// find solo busca por llave primaria
            if (editorial == null)
            {
                return NotFound(); // muestra mensaje error 404
            }
            else
            {
               return Ok(editorial); // retorna el id del editorial
            }
            
        }

        // POST: api/Editorial
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Post(Editorial nuevoEditorial )
        {

            if (!ModelState.IsValid) // verifica que el modelo de asp chequee el tipo de datos
            {
               return BadRequest(ModelState);
            }

            bibiotecaContext.Editoriales.Add(nuevoEditorial);
            bibiotecaContext.SaveChanges();
            return Ok(nuevoEditorial);
        }

        // PUT: api/Editorial/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Put(int id, Editorial editorial)
        {
            if (id !=editorial.Id)
            {
                return BadRequest(ModelState);
            }

            bibiotecaContext.Entry(editorial).State =
                System.Data.Entity.EntityState.Modified; 

            bibiotecaContext.SaveChanges();
            return Ok(editorial);
        }

        // DELETE: api/Editorial/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var editorial = bibiotecaContext.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            bibiotecaContext.Editoriales.Remove(editorial);
            bibiotecaContext.SaveChanges();
            return Ok();

        }
    }
}
