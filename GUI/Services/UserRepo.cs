using Newtonsoft.Json;

namespace H3PublisherApp.Services
{
    public class UserRepo
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<HttpResponseMessage?> SignInAsync(string name, string password)
        {
            string url = "https://localhost:7038/api/Auth/login";
            var request = new
            {
                Name = name,
                Password = password
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            return response;

        }        
    }
}
