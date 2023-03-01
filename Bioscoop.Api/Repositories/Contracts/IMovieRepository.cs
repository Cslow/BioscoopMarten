using Bioscoop.Api.Entities;

namespace Bioscoop.Api.Repositories.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
    }
}
