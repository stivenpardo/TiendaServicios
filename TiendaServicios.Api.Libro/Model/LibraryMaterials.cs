using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Libro.Model
{
    public class LibraryMaterials
    {
        [Key]
        public int LibraryMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime? DatePublication { get; set; }
        public Guid? BookAuthor { get; set; }

    }
}
