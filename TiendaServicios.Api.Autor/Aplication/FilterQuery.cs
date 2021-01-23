using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplication
{
    public class FilterQuery
    {
        public class UnicAuthor : IRequest<BookAuthor>
        {
            public string BookAuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<UnicAuthor, BookAuthor>
        {
            private readonly AuthorContext _context;
            public Handler(AuthorContext context)
            {
                _context = context;
            }
            public async Task<BookAuthor> Handle(UnicAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.BookAuth.Where(x => x.BookAuthorGuid == request.BookAuthorGuid).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                return author;
            }
        }
    }
}
