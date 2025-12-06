using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.RequestExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class Request : BaseEntity<Guid>
    {
        private List<Travelers> _travelers = new List<Travelers>();
        public Request(uint maleCount, uint femaleCount, DateTime timeOfEntrance, DateTime timeOfExit)
        {
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            TimeOfEntrance = timeOfEntrance;
            TimeOfExit = timeOfExit;
        }

        public uint MaleCount { get; private set; }
        public uint FemaleCount { get; private set; }
        public DateTime TimeOfEntrance { get; private set; }
        public DateTime TimeOfExit { get; private set; }
        public State State { get; private set; } = State.InView;
        public DateTime DateOfAcceptingRequest { get; private set; }
        public List<int> RoomIds { get; private set; }

        public IEnumerable<Travelers> Travelers => _travelers.AsReadOnly();


        #region Behaviors
        public void ChangeToAccepted()
        {
            DateOfAcceptingRequest = DateTime.Now;
            State = State.Accepted;
        }
        public void ChangeToRejected()
        {
            State = State.Rejected;
        }
        public void ChangeToInView()
        {
            State = State.InView;
        }
        public void ChangeToDone()
        {
            State = State.Done;
        }
        public void ChangeDateOfAcceptingRequest()
        {
            DateOfAcceptingRequest = DateTime.Now;
        }
        public void AddTravelers(Travelers travelers)
        {
            if (_travelers.Any(x => x == travelers))
                throw new TravelersExistsException();
            _travelers.Add(travelers);
        }
        public void RemoveTravelers(Travelers travelers)
        {
            if (!_travelers.Any(x => x == travelers))
                throw new TravelersNotExistsException();
            _travelers.Remove(travelers);
        }
        #endregion
    }
}
