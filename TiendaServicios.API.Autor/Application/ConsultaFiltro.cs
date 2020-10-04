using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.API.Autor.Model;
using TiendaServicios.API.Autor.Persitence;

namespace TiendaServicios.API.Autor.Application
{
    public class ConsultaFiltro
    {
        public class Author : IRequest<AuthorDTO>
        {
            public string AuthorGUID { get; set; }
        }

        public class Manejador : IRequestHandler<Author, AuthorDTO>
        {
            readonly ContextAuthor _context;
            readonly IMapper _mapper;
            public Manejador(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDTO> Handle(Author request, CancellationToken cancellationToken)
            {

                var author = await _context.bookAuthors
                                            .Where(author => author.AuthorLibroGuid == request.AuthorGUID)
                                            .FirstOrDefaultAsync();

                if (author == null)
                    throw new Exception("The author was not found");

                var authorDTO = _mapper.Map<BookAuthor, AuthorDTO>(author);

                return authorDTO;

            }
        }
    }
}
