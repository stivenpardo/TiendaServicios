using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplication
{
    public class Query
    {
        public class AuthorList : IRequest<List<BookAuthor>>
        { }
        public class Handler : IRequestHandler<AuthorList, List<BookAuthor>>
        {
            private readonly AuthorContext _context;

            public Handler(AuthorContext contexto)
            {
                this._context = contexto;
            }
            public async Task<List<BookAuthor>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.BookAuth.ToListAsync();

                return authors;

            }
        }
    }
}
