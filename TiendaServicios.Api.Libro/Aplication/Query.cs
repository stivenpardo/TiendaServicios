using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Aplication
{
    public class Query
    {
        public class Execute : IRequest<List<LibraryMaterialsDto>>
        {
        }
        public class Handler : IRequestHandler<Execute, List<LibraryMaterialsDto>>
        {
            private readonly LibraryContext _context;
            private readonly IMapper _mapper;
            public Handler ( LibraryContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LibraryMaterialsDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _context.LibraryMaterials.ToListAsync();
                var booksDto = _mapper.Map<List<LibraryMaterials>, List<LibraryMaterialsDto>>(books);
                return booksDto;

            }
        }
    }
}
