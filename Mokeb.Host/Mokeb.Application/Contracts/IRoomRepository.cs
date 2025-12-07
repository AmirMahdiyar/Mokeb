using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void RemoveRoomById(Room room);
        Task<bool> CheckRoomExistanceByNameAsync(string roomName, CancellationToken ct);
        Task<bool> CheckRoomExistanceByIdAsync(Guid roomId, CancellationToken ct);
        Task<Room> GetRoomById(Guid roomId, CancellationToken ct);
    }
}
