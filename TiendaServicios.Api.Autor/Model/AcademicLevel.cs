using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Model
{
    public class AcademicLevel
    {
        public int AcademicLevelId { get; set; }
        public string Name { get; set; }
        public int AcademyCenter { get; set; }
        public DateTime? GradeDate { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuthor BookAuthor { get; set; }
        public string AcedemiLevelGuid { get; set; }

    }
}
