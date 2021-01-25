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
    public class FilterQuery
    {
        public class UnicBook : IRequest<LibraryMaterialsDto>
        {
            public int BookId { get; set; }
        }

        public class Handler : IRequestHandler<UnicBook, LibraryMaterialsDto>
        {
            private LibraryContext _context;
            private IMapper _mapper;

            public Handler ( LibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<LibraryMaterialsDto> Handle(UnicBook request, CancellationToken cancellationToken)
            {
                var book = await _context.LibraryMaterials.Where(x => x.LibraryMaterialId == request.BookId).FirstOrDefaultAsync();
                
                if ( book == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                var bookDto = _mapper.Map<LibraryMaterials, LibraryMaterialsDto>(book);
                return bookDto;
            }
        }
    }
}
