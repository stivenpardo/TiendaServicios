using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Model;

namespace TiendaServicio.Api.CarritoCompra.Persintence
{
    public class CartContext : DbContext
    {
        public CartContext ( DbContextOptions<CartContext> options) : base(options) { }
        public DbSet<SessionCart> SessionCart { get; set;}
        public DbSet<SessionCartDetail> SessionCartDetail { get; set; }
    }
}
