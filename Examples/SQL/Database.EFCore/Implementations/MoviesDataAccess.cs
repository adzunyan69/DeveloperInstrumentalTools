using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class MoviesDataAccess : IMoviesDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public MoviesDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<MoviesEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Movies
                .ToListAsync(ct);
        }
    }
}