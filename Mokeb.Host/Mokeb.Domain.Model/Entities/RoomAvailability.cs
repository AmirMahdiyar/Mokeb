namespace Mokeb.Domain.Model.Entities
{
    public class RoomAvailability
    {
        public RoomAvailability(DateOnly availableDay, uint availableCapacity)
        {
            AvailableDay = availableDay;
            AvailableCapacity = availableCapacity;
        }

        public DateOnly AvailableDay { get; private set; }
        public uint AvailableCapacity { get; private set; }
        #region Behaviors
        public void RemoveFromCapacity(uint amount) => AvailableCapacity -= amount;

        public void AddFromCapacity(uint amount) => AvailableCapacity += amount;
        #endregion
    }
}
