using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.CarritoCompra.Application;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [Route("api/ShoppingCart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("{sessionId}")]
        public async Task<ActionResult<ShoppingCartDTO>> GetShoppingCart(int sessionId)
        {
            return await _mediator.Send(new Request.Execute() { SessionShopingCartId = sessionId });
        }
    }
}