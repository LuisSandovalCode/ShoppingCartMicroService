using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.API.Autor.Model;

namespace TiendaServicios.API.Autor.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookAuthor, AuthorDTO>();
        }
    }
}
