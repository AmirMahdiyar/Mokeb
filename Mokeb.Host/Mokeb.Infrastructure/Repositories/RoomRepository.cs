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

        public async Task<bool> CheckAvailabilityDayOfARoomAsync(Guid roomId, DateOnly date, CancellationToken ct)
        {
            return await _rooms.Include(x => x.RoomAvailabilities).Where(x => x.Id == roomId).SelectMany(x => x.RoomAvailabilities).AnyAsync(x => x.AvailableDay == date, ct);
        }

        public async Task<bool> CheckRoomExistanceByIdAsync(Guid roomId, CancellationToken ct)
        {
            return await _rooms.AnyAsync(x => x.Id == roomId, ct);
        }

        public async Task<bool> CheckRoomExistanceByNameAsync(string roomName, CancellationToken ct)
        {
            return await _rooms.AnyAsync(x => x.Name.ToLower() == roomName.ToLower(), ct);
        }

        public async Task<RoomAvailability> GetRoomAvailabilityByIdAsync(Guid roomId, Guid availableRoomId, CancellationToken ct)
        {
            return await _rooms.Include(x => x.RoomAvailabilities).Where(x => x.Id == roomId).SelectMany(x => x.RoomAvailabilities).SingleOrDefaultAsync(x => x.Id == availableRoomId, ct);
        }

        public async Task<Room> GetRoomByIdAsync(Guid roomId, CancellationToken ct)
        {
            return await _rooms.SingleOrDefaultAsync(x => x.Id == roomId, ct);
        }

        public void RemoveRoomById(Room room)
        {
            _rooms.Remove(room);
        }
    }
}
