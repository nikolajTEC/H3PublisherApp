
using Core.DTO;
using H3PublisherApp.Models;
using Newtonsoft.Json;
using REST_API.Objects;

namespace H3PublisherApp.Services;
public class AuthorRepo
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<List<Author>> GetAuthors()
    {
        try
        {
            // Define your API URL
            string url = "https://localhost:7038/api/Author/get-authors";


            // Call the API
            HttpResponseMessage response = await client.GetAsync(url);  
            response.EnsureSuccessStatusCode();

            // Read and parse the response body
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(responseBody);

            return authors;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}