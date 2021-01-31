using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Model;

namespace TiendaServicios.Api.Libro.Persistence
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() {  }   
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public virtual DbSet<LibraryMaterials> LibraryMaterials { get; set; }

    }
}
