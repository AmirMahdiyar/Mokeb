using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Domain.Model.Entities;
using Mokeb.Infrastructure.Context;

namespace Mokeb.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DbSet<Room> _rooms;

        public RoomRepository(MokebDbContext rooms)
        {
            _rooms = rooms.Set<Room>();
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public async Task<bool> CheckRoomExistanceByIdAsync(Guid roomId, CancellationToken ct)
        {
            return await _rooms.AnyAsync(x => x.Id == roomId);
        }

        public async Task<bool> CheckRoomExistanceByNameAsync(string roomName, CancellationToken ct)
        {
            return await _rooms.AnyAsync(x => x.Name.ToLower() == roomName.ToLower());
        }

        public async Task<Room> GetRoomById(Guid roomId, CancellationToken ct)
        {
            return await _rooms.SingleOrDefaultAsync(x => x.Id == roomId, ct);
        }

        public void RemoveRoomById(Room room)
        {
            _rooms.Remove(room);
        }
    }
}
