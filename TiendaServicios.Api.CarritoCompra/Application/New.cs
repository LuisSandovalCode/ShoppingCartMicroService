using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Model;
using TiendaServicios.Api.CarritoCompra.Persistence;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime CreateDateSession { get; set; }
            public List<string> Products { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            readonly Context _context;

            public Handler(Context context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var sessioncart = new SessionShoppingCart
                {
                    CreateDate = request.CreateDateSession
                };

                _context.sessionShoppingCarts.Add(sessioncart);
                var value = await _context.SaveChangesAsync();

                if (value <= 0)
                    throw new Exception("It was occured an error, creating the session");

                int id = sessioncart.SessionShopingCartId;

                
                foreach (var product in request.Products)
                {
                    var sessionCartDetail = new SessionShoppingCartDetail
                    {
                        SessionShopingCartId = id,
                        ProductSelected = product,
                        CreateDate = DateTime.Now
                    };

                    _context.sessionShoppingCartDetails.Add(sessionCartDetail);
                }

                value = await _context.SaveChangesAsync();

                if (value <= 0)
                    throw new Exception("It was occurd an error, to create your shopping cart");

                return Unit.Value;

            }
        }
    }
}
