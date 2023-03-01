using Bioscoop.Api.Data;
using Bioscoop.Api.Entities;
using Bioscoop.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bioscoop.Api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly BioscoopDbContext bioscoopDbContext;

        public MovieRepository(BioscoopDbContext bioscoopDbContext)
        {
            this.bioscoopDbContext = bioscoopDbContext;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var movie = await bioscoopDbContext.Movies.FindAsync(id);
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movies = await bioscoopDbContext.Movies.ToListAsync();

            return movies;
        }
    }
}
