using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class MoviesService : IMoviesService
    {
        private HttpClient HttpClient { get; }
        
        public MoviesService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<MoviesEntity>> GetWeatherForecasts()
        {
            using var response = await this.HttpClient.GetAsync("movies");

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<MoviesEntity>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}