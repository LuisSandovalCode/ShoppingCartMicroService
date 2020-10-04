using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.API.Autor.Model;
using TiendaServicios.API.Autor.Persitence;

namespace TiendaServicios.API.Autor.Application
{
    public class Consulta
    {
        public class ListaAuthor : IRequest<List<AuthorDTO>>{}

        public class Manejador : IRequestHandler<ListaAuthor, List<AuthorDTO>>
        {
            readonly ContextAuthor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorDTO>> Handle(ListaAuthor request, CancellationToken cancellationToken)
            {
                var authors = await _context.bookAuthors.ToListAsync();
                var authorsDTO = _mapper.Map<List<BookAuthor>, List<AuthorDTO>>(authors);
                return authorsDTO;
            }
        }
    }
}
