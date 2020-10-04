using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class New
    {
        public class Excecute : IRequest{
            public string Title { get; set; }
            public DateTime PublicationDate { get; set; }
            public Guid BookAuthor { get; set; }
        }

        public class ExcecuteValidation : AbstractValidator<Excecute>
        {
            public ExcecuteValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublicationDate).NotEmpty();
                RuleFor(x => x.BookAuthor).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Excecute>
        {
            readonly Context _context;

            public Handler(Context context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Excecute request, CancellationToken cancellationToken)
            {
                var book = new Book
                {
                    Title = request.Title,
                    BookAuthor = request.BookAuthor,
                    PublicationDate = request.PublicationDate
                };

                _context.Books.Add(book);
                var value = await _context.SaveChangesAsync();

                if (value > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el libro");
            }

        }
    }
}
