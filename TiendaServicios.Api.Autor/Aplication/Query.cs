using AutoMapper;
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
        public class AuthorList : IRequest<List<AuthorDto>>
        { }
        public class Handler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext contexto, IMapper mapper )
            {
                this._context = contexto;
                this._mapper = mapper;
            }
            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.BookAuth.ToListAsync();
                var authorsDto = _mapper.Map<List<BookAuthor>, List<AuthorDto>>(authors);
                return authorsDto;

            }
        }
    }
}
