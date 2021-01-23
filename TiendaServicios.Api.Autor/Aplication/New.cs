using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplication
{
    public class New
    {
        // one class is for receive data of controller API
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class ValidationsExecute : AbstractValidator<Execute>
        {
            public ValidationsExecute()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }
        //second class is where you are going to create inser data 
        public class Handler : IRequestHandler<Execute>
        {
            private readonly AuthorContext _authorContext;

            public Handler(AuthorContext authorContext)
            {
                this._authorContext = authorContext;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var bookAuthor = new BookAuthor()
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    BookAuthorGuid = Guid.NewGuid().ToString(),
                };
                _authorContext.BookAuth.Add(bookAuthor);
                var valor = await _authorContext.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el autor");
            }
        }
    }
}
