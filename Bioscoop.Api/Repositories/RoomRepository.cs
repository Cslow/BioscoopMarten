using Bioscoop.Api.Data;
using Bioscoop.Api.Entities;
using Bioscoop.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bioscoop.Api.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BioscoopDbContext bioscoopDbContext;

        public RoomRepository(BioscoopDbContext bioscoopDbContext)
        {
            this.bioscoopDbContext = bioscoopDbContext;
        }

        public async Task<Room> GetRoom(int id)
        {
            var room = await bioscoopDbContext.Rooms.FindAsync(id);
            return room;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var rooms = await bioscoopDbContext.Rooms.ToListAsync();

            return rooms;
        }
    }
}
