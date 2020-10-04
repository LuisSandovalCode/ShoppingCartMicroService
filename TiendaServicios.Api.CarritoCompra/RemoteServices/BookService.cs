using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteServices
{
    public class BookService : IBookService
    {

        readonly IHttpClientFactory _httpClient;
        readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient,ILogger<BookService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public async Task<(bool result, RemoteBook book, string ErrorMessage)> GetBook(Guid bookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var httpResponse = await client.GetAsync($"api/Book/{bookId}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<RemoteBook>(content,options);
                    return (true, result, null);
                }

                return (false, null, httpResponse.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
