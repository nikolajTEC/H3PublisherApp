using H3PublisherApp.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace H3PublisherApp.Services
{
    public class BookRepo
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task CreateBookAsync(Book book)
        {
            string url = "https://localhost:7038/api/book/create-book";

            var response = await client.PostAsJsonAsync(url, book);

        }
    }
}
