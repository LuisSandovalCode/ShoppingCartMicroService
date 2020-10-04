using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaServicios.Api.Libro.Application;
using TiendaServicios.Api.Libro.Model;

namespace TiendaServicios.Api.Libro.Tests
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
