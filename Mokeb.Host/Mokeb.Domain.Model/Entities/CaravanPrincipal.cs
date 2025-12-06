using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.States;
using Mokeb.Domain.Model.ValueObjects;

namespace Mokeb.Domain.Model.Entities
{
    public class CaravanPrincipal : Principal
    {
        protected internal List<Pilgrim> _pilgrims = new List<Pilgrim>();
        private CaravanPrincipal() { } // For ef
        public CaravanPrincipal(string name, string familyName, string nationalNumber,
            DateOnly dateOfBirth, Gender gender, string passportNumber, ContactInformation contactInformation, IdentityInformation identityInformation)
        {
            CheckName(name);
            CheckFamilyName(familyName);
            CheckNationalNumber(nationalNumber);
            CheckPassportNumber(passportNumber);

            SetState(new NoneState());

            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            NationalNumber = nationalNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PassportNumber = passportNumber;
            ContactInformation = contactInformation;
            IdentityInformation = identityInformation;
        }
        public IEnumerable<Pilgrim> Pilgrims => _pilgrims.AsReadOnly();
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
                    return TimeOfAcception.Value.AddHours(6);
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
