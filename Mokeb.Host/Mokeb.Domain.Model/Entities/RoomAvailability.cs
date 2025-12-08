using Mokeb.Domain.Model.Base;

namespace Mokeb.Domain.Model.Entities
{
    public class RoomAvailability : BaseEntity<Guid>
    {
        public RoomAvailability(DateOnly availableDay, uint availableCapacity)
        {
            Id = Guid.NewGuid();
            AvailableDay = availableDay;
            AvailableCapacity = availableCapacity;
        }

        public DateOnly AvailableDay { get; private set; }
        public uint AvailableCapacity { get; private set; }

        public Guid RoomId { get; private set; }
        #region Behaviors
        public void RemoveFromCapacity(uint amount) => AvailableCapacity -= amount;

        public void AddFromCapacity(uint amount) => AvailableCapacity += amount;
        public void ChangeAvailableDate(DateOnly availableDate)
        {
            if (AvailableDay == availableDate)
                throw new NewDateIsEqualWithOldDateException();
            AvailableDay = availableDate;
        }
        #endregion
    }
}
