using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private ILogger<MoviesController> Logger { get; }
        private IMoviesDataAccess WeatherDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public MoviesController(ILogger<MoviesController> logger, IMoviesDataAccess weatherDataAccess, IMapper mapper)
        {
            Logger = logger;
            WeatherDataAccess = weatherDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Movies>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(MoviesController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<Movies>>(await this.WeatherDataAccess.GetAllAsync(ct));
        }
    }
}