using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Model;

namespace TiendaServicios.Api.CarritoCompra.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}

        public DbSet<SessionShoppingCart> sessionShoppingCarts { get; set; }
        public DbSet<SessionShoppingCartDetail> sessionShoppingCartDetails { get; set; }
    }
}
