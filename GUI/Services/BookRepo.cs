using H3PublisherApp.Components.Pages;
using H3PublisherApp.Models;
using MudBlazor;
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

        public async Task UpdateBookAsync(Book book)
        {
            string url = "https://localhost:7038/api/book/edit-book";

            var response = await client.PostAsJsonAsync(url, book);

        }
        public async Task DeleteBookAsync(int bookId)
        {
            string url = $"https://localhost:7038/api/book/delete-book?bookId={bookId}";

            var response = await client.PostAsJsonAsync(url, bookId);

        }
        public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            try
            {
                // Define your API URL
                string url = $"https://localhost:7038/api/book/get-books-by-authorId?authorId={authorId}";


                // Call the API
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read and parse the response body
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(responseBody);

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                // Define your API URL
                string url = "https://localhost:7038/api/book/get-books";


                // Call the API
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read and parse the response body
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(responseBody);

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Book>> GetBooksBySearchCriterias(string? name, DateRange? daterange, double? price, bool under)
        {
            try
            {
                var request = new
                {
                    Name = name,
                    StartDate = daterange.Start,
                    EndDate = daterange.End,
                    Price = price,
                    Under = under

                };
                // Define your API URL
                string url = "https://localhost:7038/api/book/search-books";


                // Call the API
                var response = await client.PostAsJsonAsync(url, request);
                response.EnsureSuccessStatusCode();

                // Read and parse the response body
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(responseBody);

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        //bookrepo.GetBooksBySearchCriterias(_name, _dateRange, _price, under);
    }
}
