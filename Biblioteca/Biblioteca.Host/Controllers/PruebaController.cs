using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblioteca.Host.Controllers
{
    public class PruebaController : ApiController
    {
        [Route("api/Prueba/Buscar/{nombre}")]// este atributo sirve para llamar al metodo buscarpornombre lo
        [HttpGet,HttpPost]// SI NO COLOCO ESTO ATRIBUTO NO RECIBE EL GET PARA RECIBIR EL PARAMETRO
        //httpget y post da permiso que es lo que recibe o no
        public IEnumerable<string>BuscarPorNombre(string nombre)// que en corchetede del atributo debe ser el mismo nombre del (string nombre)
        {
            return new string[] { "Nombre1", "Nombre2","prueba111" };
        }
        // GET: api/Prueba
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prueba/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prueba
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prueba/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prueba/5
        public string Delete(int id)
        {
            return "eliminado";
        }
    }
}
