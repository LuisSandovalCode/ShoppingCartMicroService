using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.API.Autor.Model;

namespace TiendaServicios.API.Autor.Persitence
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options){}
        public DbSet<AcademicGrade> academicGrades { get; set; }
        public DbSet<BookAuthor> bookAuthors { get; set; }


    }
}
