using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Aplication;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new Query.AuthorList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetBookAuthor(string id)
        {
            return await _mediator.Send(new FilterQuery.UnicAuthor { BookAuthorGuid = id });
        }
    }
}
