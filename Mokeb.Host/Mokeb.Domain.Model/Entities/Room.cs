using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class Room : BaseEntity<Guid>
    {
        private List<Companion> _companions = new List<Companion>();
        private List<IndividualPrincipal> _individualPrincipal = new List<IndividualPrincipal>();

        public Room(string name, Gender gender, DateOnly dateOfStartingService, DateOnly dateOfEndingService, uint capacity)
        {
            Name = name;
            Gender = gender;
            DateOfStartingService = dateOfStartingService;
            DateOfEndingService = dateOfEndingService;
            Capacity = capacity;
            AvailableCapacity = capacity;
        }

        private Room() { } //For ef

        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly DateOfStartingService { get; private set; }
        public DateOnly DateOfEndingService { get; private set; }
        public uint Capacity { get; private set; }
        public uint AvailableCapacity { get; private set; }

        public Guid? ConvoyPrincipalId { get; private set; }


        #region Behaviors
        public void AddIndividual(IndividualPrincipal individualPrincipal)
        {
            CheckForCapacity();
            CheckIndividualExistance(individualPrincipal);
            AvailableCapacity--;
            _individualPrincipal.Add(individualPrincipal);
        }


        public void RemoveIndividual(IndividualPrincipal individualPrincipal)
        {
            CheckingRoomForIndividual(individualPrincipal);
            AvailableCapacity++;
            _individualPrincipal.Remove(individualPrincipal);
        }


        public void AddCompanion(Companion companion)
        {
            CheckForCapacity();
            CheckCompanionExistance(companion);
            AvailableCapacity--;
            _companions.Add(companion);
        }


        public void RemoveCompanion(Companion companion)
        {
            CheckingRoomForCompanion(companion);
            AvailableCapacity++;
            _companions.Remove(companion);
        }


        public void AssignClassToConvoy(Guid convoyPrincipalId)
        {
            ConvoyPrincipalId = convoyPrincipalId;
            AvailableCapacity = 0;
        }
        public void UnassignConvoy()
        {
            if (ConvoyPrincipalId is null) return;

            ConvoyPrincipalId = null;
            AvailableCapacity = Capacity;
        }

        #endregion
        #region Validations
        private void CheckingRoomForIndividual(IndividualPrincipal individualPrincipal)
        {
            if (!_individualPrincipal.Any(x => x == individualPrincipal))
                throw new IndividualNotFoundException();
        }
        private void CheckIndividualExistance(IndividualPrincipal individualPrincipal)
        {
            if (_individualPrincipal.Any(x => x == individualPrincipal))
                throw new ThisUserIsInThisRoomException();
        }

        private void CheckForCapacity()
        {
            if (AvailableCapacity == 0)
                throw new NotEnoughCapacityForNewUserException();
        }

        private void CheckCompanionExistance(Companion companion)
        {
            if (_companions.Any(x => x == companion))
                throw new ThisUserIsInThisRoomException();
        }
        private void CheckingRoomForCompanion(Companion companion)
        {
            if (!_companions.Any(x => x == companion))
                throw new CompanionNotFoundException();
        }
        #endregion
    }
}
