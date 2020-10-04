using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Autor.Application;
using TiendaServicios.API.Autor.Model;

namespace TiendaServicios.API.Autor.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("CreateAuthor")]
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateAuthor(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }


        [Route("Authors")]
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
        {
            return await _mediator.Send(new Consulta.ListaAuthor());
        }

        [Route("AuthorById")]
        [HttpGet]
        public async Task<ActionResult<AuthorDTO>> GetAuthorById(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.Author { AuthorGUID = id });
        }


    }
}