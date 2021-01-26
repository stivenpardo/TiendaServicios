using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompra.Aplication
{
    public class CartDto
    {
        public int CartId { get; set; }
        public DateTime? CreationDateSesion { get; set; }
        public List<DetailCartDto> ListProducts { get; set; }
    }
}
