using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Aplication;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryMaterials : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibraryMaterials(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet]
        public async Task<ActionResult<List<LibraryMaterialsDto>>> GetBooks()
        {
            return await _mediator.Send(new Query.Execute());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryMaterialsDto>> GetUnicBook(int id)
        {
            return await _mediator.Send(new FilterQuery.UnicBook { BookId = id});
        }

    }
}
