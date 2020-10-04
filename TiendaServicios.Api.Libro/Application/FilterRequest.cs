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
    public class FilterRequest
    {
        public class BookOnly : IRequest<BookDTO> {
            public Guid? BookId { get; set; }
        }

        public class Execute : IRequestHandler<BookOnly, BookDTO>
        {
            readonly Context _context;
            readonly IMapper _mapper;

            public Execute(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDTO> Handle(BookOnly request, CancellationToken cancellationToken)
            {
                var book = await _context.Books
                                        .Where(book => book.BookId == request.BookId)
                                        .FirstOrDefaultAsync();

                if (book == null)
                    throw new Exception("The book was not found");

                return _mapper.Map<Book, BookDTO>(book);
            }
        }


    }
}
