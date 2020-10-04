using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Libro.Application
{
    public class BookDTO
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
    }
}
