using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Model
{
    public class SessionShoppingCartDetail
    {
        [Key]
        public int SessionShoppingCartDetailId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ProductSelected { get; set; }
        public int SessionShopingCartId { get; set; }
    }
}
