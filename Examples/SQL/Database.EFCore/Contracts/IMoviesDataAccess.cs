using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Entities;

namespace Database.EFCore.Contracts
{
    public interface IMoviesDataAccess
    {
        Task<IEnumerable<MoviesEntity>> GetAllAsync(CancellationToken ct = default);
    }
}