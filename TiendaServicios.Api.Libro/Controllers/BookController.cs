using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Application;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Excecute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks()
        {
            return await _mediator.Send(new Request.Execute());
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<BookDTO>> GetBookById(Guid bookId)
        {
            return await _mediator.Send(new FilterRequest.BookOnly() { BookId = bookId });
        }
    }
}