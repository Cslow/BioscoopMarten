using Bioscoop.Api.Data;
using Bioscoop.Api.Entities;
using Bioscoop.Api.Repositories.Contracts;
using Bioscoop.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bioscoop.Api.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly BioscoopDbContext bioscoopDbContext;

        public ShowRepository(BioscoopDbContext bioscoopDbContext)
        {
            this.bioscoopDbContext = bioscoopDbContext;
        }

        public async Task<Show> AddShow(ShowToAddDto showToAddDto)
        {
            var show = await (from movie in this.bioscoopDbContext.Movies
                              where movie.Id == showToAddDto.MovieId
                              
                              from room in this.bioscoopDbContext.Rooms
                              where room.Id == showToAddDto.RoomId
                              
                              select new Show
                              {
                                  MovieId = movie.Id,
                                  RoomId = room.Id,
                                  StartDateTime = showToAddDto.StartDateTime
                              }).SingleOrDefaultAsync();
            if (show != null)
            {
                var result = await this.bioscoopDbContext.Shows.AddAsync(show);
                await this.bioscoopDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Show> DeleteShow(int id)
        {
            var show = await this.bioscoopDbContext.Shows.FindAsync(id);

            if (show != null) 
            {
                this.bioscoopDbContext.Shows.Remove(show);
                await this.bioscoopDbContext.SaveChangesAsync();
            }

            return show;
        }

        public async Task<Show> GetShow(int id)
        {
            var show = await bioscoopDbContext.Shows.FindAsync(id);
            return show;
        }

        public async Task<IEnumerable<Show>> GetShows()
        {
            var shows = await bioscoopDbContext.Shows.ToListAsync();
            return shows;
        }
    }
}
