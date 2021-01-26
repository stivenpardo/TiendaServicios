using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.RemoteInterface;
using TiendaServicio.Api.CarritoCompra.RemoteModel;

namespace TiendaServicio.Api.CarritoCompra.RemoteService
{
    public class BooksService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BooksService> _logger;

        public BooksService(IHttpClientFactory httpClient, ILogger<BooksService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(int BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/LibraryMaterials/{BookId}");
                if (response.IsSuccessStatusCode)
                {
                    var content= await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<BookRemote>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
