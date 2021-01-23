using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Model
{
    public class BookAuthor
    {
        public int BookAuthorId{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate{ get; set; }
        public ICollection<AcademicLevel> AcademyLevelList { get; set; }
        public string BookAuthorGuid { get; set; }
    }
}
