using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class ShoppingCartDTO
    {
        public int SessionShopingCartId { get; set; }
        public DateTime? CreateDate { get; set; }
        public List<DetailShoppingCartDTO> Books { get; set; }
    }
}
