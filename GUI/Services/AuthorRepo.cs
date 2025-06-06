using H3PublisherApp.Models;
using Newtonsoft.Json;

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
    public async Task CreateAuthorAsync(string firstname, string lastname)
    {
        string url = "https://localhost:7038/api/Author/create-author";
        var request = new
        {
            FirstName = firstname,
            LastName = lastname
        };

        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

    }   
}