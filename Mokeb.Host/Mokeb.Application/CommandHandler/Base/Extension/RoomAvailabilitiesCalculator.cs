using Mokeb.Application.Exceptions;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.CommandHandler.Base.Extension
{
    public static class RoomAvailabilitiesCalculator
    {
        public static void DecreaseFromRoomAvailableCapacity(List<RoomAvailability> roomAvailabilities, uint maleAmount, uint femaleAmount)
        {
            var overallAmount = maleAmount + femaleAmount;
            foreach (var roomAvailability in roomAvailabilities)
            {
                if (overallAmount == 0)
                    break;
                else if (overallAmount > roomAvailability.AvailableCapacity)
                {
                    overallAmount -= roomAvailability.AvailableCapacity;
                    roomAvailability.RemoveFromCapacity(roomAvailability.AvailableCapacity);
                }
                else
                {
                    roomAvailability.RemoveFromCapacity(overallAmount);
                    overallAmount = 0;
                }
            }
            if (overallAmount != 0)
                throw new ThereIsNotEnoughSpaceException();
        }
        public static void IncreaseRoomAvailableCapacity(List<RoomAvailability> roomAvailabilities, uint maleAmount, uint femaleAmount)
        {
            var amountToFree = maleAmount + femaleAmount;

            foreach (var room in roomAvailabilities)
            {
                if (amountToFree == 0)
                    break;
                var occupiedSpace = room.Room.Capacity - room.AvailableCapacity;

                if (occupiedSpace == 0) continue;

                if (amountToFree >= occupiedSpace)
                {
                    room.AddFromCapacity((uint)occupiedSpace);

                    amountToFree -= (uint)occupiedSpace;
                }
                else
                {
                    room.AddFromCapacity(amountToFree);
                    amountToFree = 0;
                }
            }
        }
    }
}
