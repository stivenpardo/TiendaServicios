using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Aplication
{
    public class New
    {
        public class Execute: IRequest
        {
            public int LibraryMaterialId { get; set; }
            public string Title { get; set; }
            public DateTime? DatePublication { get; set; }
            public Guid? BookAuthor { get; set; }
        }
        
        public class ExecuteValidations : AbstractValidator<Execute>
        {
            public ExecuteValidations()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.DatePublication).NotEmpty();
                RuleFor(x => x.BookAuthor).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Execute>
        {
            private readonly LibraryContext _context;
            public Handler( LibraryContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new LibraryMaterials
                {
                    Title = request.Title,
                    DatePublication = request.DatePublication,
                    BookAuthor = request.BookAuthor,
                };

                _context.LibraryMaterials.Add(book);
                var value = await _context.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el libro");
            }
        }
    }
}
