using Bioscoop.Api.Entities;

namespace Bioscoop.Api.Repositories.Contracts
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> GetRoom(int id);
    }
}
