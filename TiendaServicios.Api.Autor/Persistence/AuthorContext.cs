using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Persistence
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }
        public DbSet<BookAuthor> BookAuth { get; set; }
        public DbSet<AcademicLevel> AcademyLevel { get; set; }

    }
}
