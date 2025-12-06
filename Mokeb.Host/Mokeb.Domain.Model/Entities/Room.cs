using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class Room : BaseEntity<Guid>
    {
        private List<RoomAvailability> _availability = new List<RoomAvailability>();
        public Room(string name, Gender gender, uint capacity)
        {
            CheckName(name);

            Id = Guid.NewGuid();
            Name = name;
            Gender = gender;
            Capacity = capacity;
        }

        private Room() { } //For ef

        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public uint Capacity { get; private set; }

        public IEnumerable<RoomAvailability> RoomAvailabilities => _availability.AsReadOnly();

        #region Validations
        public void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new NameIsInvalidException();
        }
        #endregion
    }
}
