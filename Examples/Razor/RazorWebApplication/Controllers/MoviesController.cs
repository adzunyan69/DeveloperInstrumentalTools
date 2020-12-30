using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesService WeatherForecastService { get; }
        
        public MoviesController(IMoviesService weatherForecastService)
        {
            WeatherForecastService = weatherForecastService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.WeatherForecastService.GetWeatherForecasts());
        }

        public IActionResult Details(MoviesEntity model)
        {
            return this.View(model);
        }
    }
}