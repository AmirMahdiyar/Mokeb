using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Exceptions.IndividualExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class IndividualRequest : Request
    {
        public IndividualRequest(uint maleCount, uint femaleCount, DateTime timeOfEntrance, DateTime timeOfExit, Guid principalId)
        {
            CheckOverallAmount(maleCount, femaleCount);

            Id = Guid.NewGuid();
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            TimeOfEntrance = timeOfEntrance;
            TimeOfExit = timeOfExit;
            PrincipalId = principalId;
        }

        public Guid PrincipalId { get; private set; }

        #region Validation
        private void CheckOverallAmount(uint maleCount, uint femaleCount)
        {
            if ((maleCount + femaleCount) > 5)
                throw new IndividualOverallCapacityException();
        }
        #endregion
    }
}
