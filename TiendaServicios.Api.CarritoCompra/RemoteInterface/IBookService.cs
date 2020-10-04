using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
    public interface IBookService
    {
        Task<(bool result, RemoteBook book, string ErrorMessage)> GetBook(Guid bookId);
    }
}
