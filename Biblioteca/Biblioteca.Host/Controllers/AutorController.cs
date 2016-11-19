using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Http.Description;

namespace Biblioteca.Host.Controllers
{
    public class AutorController : ApiController
    {
        BibliotecaContext bibiotecaContext = new BibliotecaContext("BibliotecaMaestro");

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibiotecaContext.Dispose();
            }
            base.Dispose(disposing);
        }

        [Route("api/Autor/{idAutor}/libro")]
        [HttpPut]
        public IHttpActionResult AgregarLibro(int idAutor, Libro nuevoLibro)
        {
            Autor autor = bibiotecaContext.Autores.Find(idAutor);
            if (autor == null)
            {
                return NotFound();
            }

            autor.AgregarLibro(nuevoLibro);
            bibiotecaContext.SaveChanges();

            return Ok(autor);
        }

        // GET: api/Autores
        public IEnumerable<Autor> Get()
        {
            return bibiotecaContext.Autores;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Get(int id)
        {
            var autores = bibiotecaContext.Autores
                .Include("Libros") //incluye la listade los libros para que aparesca junto con los autores
                .First(a => a.Id == id);// first devuelve el primer valor de la lista

            if (autores == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(autores);
            }
        }

        // POST: api/Autores
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Post(Autor nuevoAutor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bibiotecaContext.Autores.Add(nuevoAutor);
            bibiotecaContext.SaveChanges();
            return Ok(nuevoAutor);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Put(int id, Autor autor)
        {
            if (id!=autor.Id)
            {
                return BadRequest(ModelState);
            }
            bibiotecaContext.Entry(autor).State = System.Data.Entity.EntityState.Modified;
            bibiotecaContext.SaveChanges();
            return Ok(autor);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Delete(int id)
        {
            var autor = bibiotecaContext.Autores.Find(id);
            if (autor == null)
            {
                return NotFound();
            }
            bibiotecaContext.Autores.Remove(autor);
            bibiotecaContext.SaveChanges();
            return Ok();
        }

    }
}
