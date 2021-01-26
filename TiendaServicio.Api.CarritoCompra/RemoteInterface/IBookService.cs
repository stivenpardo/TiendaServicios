using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.RemoteModel;

namespace TiendaServicio.Api.CarritoCompra.RemoteInterface
{
    public interface IBookService
    {
        Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(int BookId);

    }
}
