using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class Request
    {
        public class Execute : IRequest<List<BookDTO>> { }

        public class Handler : IRequestHandler<Execute, List<BookDTO>>
        {
            readonly Context _context;
            readonly IMapper _mapper;

            public Handler(Context context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDTO>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _context.Books.ToListAsync();
                return _mapper.Map<List<Book>, List<BookDTO>>(books);
            }
        }
    }
}
