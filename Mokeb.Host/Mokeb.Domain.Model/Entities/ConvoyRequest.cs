using Mokeb.Domain.Model.Base;

namespace Mokeb.Domain.Model.Entities
{
    public class ConvoyRequest : Request
    {
        public ConvoyRequest(uint maleCount, uint femaleCount, DateTime timeOfEntrance, DateTime timeOfExit)
        {
            Id = Guid.NewGuid();
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            TimeOfEntrance = timeOfEntrance;
            TimeOfExit = timeOfExit;
        }
        public DateTime? DateOfAcceptingRequest { get; private set; }

        #region behaviors
        public override void ChangeToAccepted()
        {
            DateOfAcceptingRequest = DateTime.Now;
            base.ChangeToAccepted();
        }
        #endregion
    }

}
