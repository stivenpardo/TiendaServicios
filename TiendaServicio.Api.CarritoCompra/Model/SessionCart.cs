using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompra.Model
{
    public class SessionCart
    {
        [Key]
        public int SesionCartId { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<SessionCartDetail> DetailList { get; set; }
    }
}
