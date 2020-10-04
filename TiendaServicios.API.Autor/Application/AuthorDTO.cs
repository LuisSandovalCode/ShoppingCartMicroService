using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.API.Autor.Application
{
    public class AuthorDTO
    {
        public string BookAuthorName { get; set; }
        public string BookAuthorLastName { get; set; }
        public DateTime? BookAuthorBirthName { get; set; }
        public string AuthorLibroGuid { get; set; }
    }
}
