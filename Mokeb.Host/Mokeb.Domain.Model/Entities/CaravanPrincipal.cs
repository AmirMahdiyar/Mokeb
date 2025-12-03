using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;
using Mokeb.Domain.Model.Exceptions.RoomExceptions;
using Mokeb.Domain.Model.States;

namespace Mokeb.Domain.Model.Entities
{
    public class CaravanPrincipal : Principal
    {
        protected internal List<CaravanRequest> _requests = new List<CaravanRequest>();
        protected internal List<Pilgrim> _pilgrims = new List<Pilgrim>();
        private List<Room> _rooms = new List<Room>();
        private const Role role = Role.CaravanAccount;
        private CaravanPrincipal() { } // For ef
        public CaravanPrincipal(string name, string familyName, string nationalNumber, string gmail,
            string phoneNumber, string emergencyPhoneNumber, DateOnly dateOfBirth,
            Gender gender, string passportNumber, string username, string password)
        {
            CheckName(name);
            CheckFamilyName(familyName);
            CheckNationalNumber(nationalNumber);
            CheckGmail(gmail);
            CheckPassportNumber(passportNumber);
            CheckPhoneNumber(phoneNumber);
            CheckPhoneNumber(emergencyPhoneNumber);
            CheckUsername(username);
            CheckPassword(password);

            SetState(new NoneState());

            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            NationalNumber = nationalNumber;
            Gmail = gmail;
            PhoneNumber = phoneNumber;
            EmergencyPhoneNumber = emergencyPhoneNumber;
            DateOfBirth = dateOfBirth;
            Role = role;
            Gender = gender;
            PassportNumber = passportNumber;
            Username = username;
            Password = password;
        }
        public IEnumerable<CaravanRequest> Requests => _requests.AsReadOnly();
        public IEnumerable<Pilgrim> Pilgrims => _pilgrims.AsReadOnly();
        public IEnumerable<Room> Rooms => _rooms.AsReadOnly();
        public DateTime? TimeOfAcception
        {
            get
            {
                var last = Requests.LastOrDefault();
                return last?.State == State.Accepted ? last.DateOfAcceptingRequest : null;
            }
        }
        public ConvoyState ConvoyState { get; private set; }
        public DateTime? EstimatedTimeForAddingPilgrims
        {
            get
            {
                if (ConvoyState is InProcessState && TimeOfAcception is not null)
                {
                    return TimeOfAcception.Value.AddHours(6);
                }
                return null;
            }
        }
        public void SetState(ConvoyState state)
        {
            ConvoyState = state;
            state.SetConvoy(this);
        }


        #region Behaviors
        public void ChangeStateToNone()
        {
            SetState(new NoneState());
        }
        public void ChangeStateToInProcess()
        {
            SetState(new InProcessState());
        }
        public void ChangeStateToDone()
        {
            SetState(new DoneState());
        }
        public void ChangeStateToDelayEntrance()
        {
            SetState(new DelayInEntranceState());
        }
        public void AddRoom(Room room)
        {
            if (Rooms.Any(x => x == room))
                throw new ThisConvoyAlreadyHasThisRoomException();
            _rooms.Add(room);
        }
        public void RemoveRoom(Room room)
        {
            if (!Rooms.Any(y => y == room))
                throw new RoomNotFoundException();
            _rooms.Remove(room);
        }
        public void AddPilgrim(Pilgrim pilgrim)
        {
            ConvoyState.AddPilgrim(pilgrim);
        }
        public void RemovePilgrim(Pilgrim pilgrim)
        {
            ConvoyState.RemovePilgrim(pilgrim);
        }

        #endregion
    }
}
