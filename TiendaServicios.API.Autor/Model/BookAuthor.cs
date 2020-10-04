using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.API.Autor.Model
{
    public class BookAuthor
    {
        [Key]
        public int IdBookAuthor { get; set; }
        public string BookAuthorName { get; set; }
        public string BookAuthorLastName { get; set; }
        public DateTime? BookAuthorBirthName { get; set; }
        public ICollection<AcademicGrade> AcademicGrades { get; set; }
        public string AuthorLibroGuid { get; set; }
    }
}
