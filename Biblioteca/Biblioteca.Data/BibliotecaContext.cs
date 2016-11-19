
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using Biblioteca.Data.Modelos;

namespace Biblioteca.Data
{
    public class BibliotecaContext : DbContext //hereda de dbcontext

    {
        public BibliotecaContext() { }
        public BibliotecaContext (String ConnectionName) : base (ConnectionName)// el base llama al constructor
                                                            // de la clase padre para enviar el string de connection

        {
            
        }
        public DbSet<Libro> Libros { get; set; } 

        public DbSet<Editorial> Editoriales { get; set; }

        public DbSet<Autor> Autores { get; set; }



    }
}
