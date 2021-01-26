using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Persintence;
using TiendaServicio.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicio.Api.CarritoCompra.Aplication
{
    public class Query 
    {
        public class Execute : IRequest<CartDto>
        {
            public int CartSesionId { get; set; }
        }
        public class Handler : IRequestHandler<Execute, CartDto>
        {
            private readonly CartContext _context;
            private readonly IBookService _bookService;
            public Handler( CartContext context, IBookService bookService)
            {
                _context = context;
                _bookService = bookService;
            }
            public async Task<CartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var cartSesion = await _context.SessionCart.FirstOrDefaultAsync(x => x.SesionCartId == request.CartSesionId);
                var CartSesionDetail = await _context.SessionCartDetail.Where(x => x.SesionCartId == request.CartSesionId).ToListAsync();

                var listCartDto = new List<DetailCartDto>();
                foreach(var book in CartSesionDetail)
                {
                    var response = await _bookService.GetBook(Convert.ToInt32(book.SelectedProduct));
                    if (response.result)
                    {
                        var bookObj = response.Book;
                        var detailCart = new DetailCartDto
                        {
                            BookTitle = bookObj.Title,
                            DatePublication = bookObj.DatePublication,
                            BookId = bookObj.LibraryMaterialId,
                        };
                        listCartDto.Add(detailCart);
                    }
                }
                var SesionCartDto = new CartDto
                {
                    CartId = cartSesion.SesionCartId,
                    CreationDateSesion = cartSesion.CreationDate,
                    ListProducts = listCartDto,              
                };
                return SesionCartDto;
            }
        }
    }
}
