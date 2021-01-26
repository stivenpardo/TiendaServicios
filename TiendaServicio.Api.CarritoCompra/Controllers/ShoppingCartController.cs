using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Aplication;
using TiendaServicio.Api.CarritoCompra.Model;

namespace TiendaServicio.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mapper)
        {
            _mediator = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> GetCart (int id)
        {
            return await _mediator.Send(new Query.Execute { CartSesionId = id });
        }
    }
}
