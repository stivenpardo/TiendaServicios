using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.CarritoCompra.Model
{
    public class SessionCartDetail
    {
        [Key]
        public int SesionCartDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string SelectedProduct { get; set; }
        public int SesionCartId { get; set; }
        public SessionCart SesionCart { get; set; }    
    }
}
