using Bioscoop.Api.Entities;
using Bioscoop.Models.Dtos;

namespace Bioscoop.Api.Repositories.Contracts
{
    public interface IShowRepository
    {
        Task<Show> AddShow(ShowToAddDto showToAddDto);
        Task<Show> DeleteShow(int id);
        Task<IEnumerable<Show>> GetShows();
        Task<Show> GetShow(int id);
    }
}
