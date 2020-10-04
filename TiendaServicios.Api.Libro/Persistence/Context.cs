using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Model;

namespace TiendaServicios.Api.Libro.Persistence
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<Book> Books { get; set; }
    }
}
