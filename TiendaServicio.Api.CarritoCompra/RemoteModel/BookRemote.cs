using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompra.RemoteModel
{
    public class BookRemote
    {
        public int LibraryMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime? DatePublication { get; set; }
        public Guid? BookAuthor { get; set; }
    }
}
