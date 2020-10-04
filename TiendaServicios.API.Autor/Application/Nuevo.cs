using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.API.Autor.Model;
using TiendaServicios.API.Autor.Persitence;

namespace TiendaServicios.API.Autor.Application
{
    public class Nuevo
    {
        /// <summary>
        /// SE COMUNICA CON EL CONTROLLER Y DESDE EL 
        /// CONTROLLER RECIBE LOS PARAMETROS
        /// </summary>
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(field => field.Nombre).NotEmpty();
                RuleFor(field => field.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextAuthor _context;

            public Manejador(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new BookAuthor
                {
                    BookAuthorName = request.Nombre,
                    BookAuthorLastName = request.Apellido,
                    BookAuthorBirthName = request.FechaNacimiento,
                    AuthorLibroGuid = Guid.NewGuid().ToString()
                };

                _context.bookAuthors.Add(autorLibro);
                var valorInsersion = await _context.SaveChangesAsync();

                if (valorInsersion > 0)
                    return Unit.Value;
                else
                    throw new Exception("No se pudo insertar el autor del libro");

            }
        }

    }
}
