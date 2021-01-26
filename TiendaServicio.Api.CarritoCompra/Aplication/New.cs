using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Model;
using TiendaServicio.Api.CarritoCompra.Persintence;

namespace TiendaServicio.Api.CarritoCompra.Aplication
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime? CreationDate { get; set; }
            public List<string> ListProduct { get; set; }
        }
        public class Handler : IRequestHandler<Execute>
        {
            private CartContext _context;

            public Handler (CartContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var sesionCart = new SessionCart
                {
                    CreationDate = request.CreationDate,                
                };

                _context.SessionCart.Add(sesionCart);
                var value = await _context.SaveChangesAsync();
                if (value == 0)
                {
                    throw new Exception("la sesion del carrito no se pudo insertar");
                }

                int id = sesionCart.SesionCartId; 

                foreach ( var obj  in request.ListProduct )
                {
                    var detailSesion = new SessionCartDetail
                    {
                        CreationDate = DateTime.Now,
                        SesionCartId = id,
                        SelectedProduct = obj,
                    };

                    _context.SessionCartDetail.Add(detailSesion);
                }
                value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insetar el detalle del carrito compras");

            }
        }
    }
}
