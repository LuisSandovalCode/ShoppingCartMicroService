using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Persistence;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class Request
    {
        public class Execute : IRequest<ShoppingCartDTO>
        {
            public int SessionShopingCartId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, ShoppingCartDTO>
        {
            readonly Context _context;
            readonly IBookService _service;
            public Handler(Context context, IBookService service)
            {
                _context = context;
                _service = service;
            }

            public async Task<ShoppingCartDTO> Handle(Execute request, CancellationToken cancellationToken)
            {
                var shoppingCartSession = await _context.sessionShoppingCarts
                                                        .FirstOrDefaultAsync(x => x.SessionShopingCartId == request.SessionShopingCartId);

                var shoppingCartSessionDetail = await _context.sessionShoppingCartDetails
                                                        .Where(x => x.SessionShopingCartId == request.SessionShopingCartId)
                                                        .ToListAsync();
                List<DetailShoppingCartDTO> shoppingCartSessionDetailDTO = new List<DetailShoppingCartDTO>();
                foreach (var book in shoppingCartSessionDetail)
                {
                    var response = await _service.GetBook(new Guid(book.ProductSelected));

                    if (response.result)
                    {
                        shoppingCartSessionDetailDTO.Add(new DetailShoppingCartDTO
                        { 
                            BookAuthor = response.book.BookAuthor,
                            BookId = response.book.BookId,
                            PublicationDate = response.book.PublicationDate,
                            Title = response.book.Title
                        });
                    }
                }

                return new ShoppingCartDTO
                {
                    Books = shoppingCartSessionDetailDTO,
                    CreateDate = shoppingCartSession.CreateDate,
                    SessionShopingCartId = shoppingCartSession.SessionShopingCartId
                };
            }
        }
    }
}
