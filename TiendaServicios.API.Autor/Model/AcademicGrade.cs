using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.API.Autor.Model
{
    public class AcademicGrade
    {
        public int AcademicGradeId { get; set; }
        public string AcademicGradeName { get; set; }
        public string AcademicPlace { get; set; }
        public DateTime? AcademicDate { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuthor bookAuthor { get; set; }
        public string AcademicGradeGuid { get; set; }
    }
}
