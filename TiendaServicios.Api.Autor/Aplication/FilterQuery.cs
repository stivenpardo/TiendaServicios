using AutoMapper;
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
        public class UnicAuthor : IRequest<AuthorDto>
        {
            public string BookAuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<UnicAuthor,AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;
            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<AuthorDto> Handle(UnicAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.BookAuth.Where(x => x.BookAuthorGuid == request.BookAuthorGuid).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var authorDto = _mapper.Map<BookAuthor, AuthorDto>(author);
                return authorDto;
            }
        }
    }
}
