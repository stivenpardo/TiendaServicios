using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompra.Aplication
{
    public class DetailCartDto
    {
        public int? BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? DatePublication { get; set; }


    }
}
