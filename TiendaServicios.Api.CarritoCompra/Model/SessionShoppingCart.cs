using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Model
{
    public class SessionShoppingCart
    {
        [Key]
        public int SessionShopingCartId { get; set; }
        public DateTime? CreateDate { get; set; }
        public ICollection<SessionShoppingCartDetail> Details { get; set; }
    }
}
