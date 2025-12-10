using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Application.Dtos;
using Mokeb.Domain.Model.Entities;
using Mokeb.Domain.Model.Enums;
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

        public async Task<RoomAvailability> GetRoomAvailabilityByIdAsync(Guid availableRoomId, CancellationToken ct)
        {
            return await _rooms.Include(x => x.RoomAvailabilities).SelectMany(x => x.RoomAvailabilities).SingleOrDefaultAsync(x => x.Id == availableRoomId, ct);
        }

        public async Task<List<RoomAvailability>> GetAvailabilitiesByRoomIdAndDatesAsync(Guid roomId, List<DateOnly> dates, CancellationToken ct)
        {
            return await _rooms.Include(x => x.RoomAvailabilities)
            .SelectMany(x => x.RoomAvailabilities)
            .Where(ra => ra.RoomId == roomId && dates.Contains(ra.AvailableDay))
            .ToListAsync(ct);
        }

        public async Task<Room> GetRoomByIdAsync(Guid roomId, CancellationToken ct)
        {
            return await _rooms.SingleOrDefaultAsync(x => x.Id == roomId, ct);
        }

        public async Task<int> GetSumOfAllFemaleRoomsCapacities(CancellationToken ct)
        {
            return await _rooms.Where(x => x.Gender == Gender.Female).SumAsync(x => (int)x.Capacity, ct);
        }

        public async Task<int> GetSumOfAllMaleRoomsCapacities(CancellationToken ct)
        {
            return await _rooms.Where(x => x.Gender == Gender.Male).SumAsync(x => (int)x.Capacity, ct);
        }

        public async Task<int> GetSumOfAllRoomsCapacities(CancellationToken ct)
        {
            return await _rooms
                .SumAsync(x => (int)x.Capacity, ct);
        }

        public async Task<int> GetSumOfAvailableCapacityAtADay(DateOnly date, CancellationToken ct)
        {
            return await _rooms
                .Include(x => x.RoomAvailabilities)
                .SelectMany(x => x.RoomAvailabilities)
                .Where(x => x.AvailableDay == date)
                .SumAsync(x => (int)x.AvailableCapacity, ct);
        }

        public void RemoveRoomById(Room room)
        {
            _rooms.Remove(room);
        }
        public async Task<List<RoomAvailabilityDto>> GetDistinctRoomAvailabilitesFromEnteredRoomIdList(List<Guid> roomIds, List<DateOnly> dateRange, CancellationToken ct)
        {
            return await _rooms
                    .Where(r => !roomIds.Contains(r.Id))
                    .SelectMany(r => r.RoomAvailabilities, (room, availability) => new { room, availability })
                    .Where(x => dateRange.Contains(x.availability.AvailableDay))
                    .Select(x => new RoomAvailabilityDto(
                        x.availability.AvailableDay,
                        x.availability.AvailableCapacity,
                        x.room.Gender,
                        x.room.Capacity,
                        x.room.Capacity - x.availability.AvailableCapacity
                    ))
                    .ToListAsync(ct);
        }
    }
}
