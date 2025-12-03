using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Exceptions.IndividualExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class IndividualRequest : Request
    {
        private List<Companion> _companions = new List<Companion>();
        public IndividualRequest(DateTime timeOfEntrance, DateTime timeOfExit, List<Companion> companions, Guid principalId, IndividualPrincipal principal)
        {

            Id = Guid.NewGuid();
            MaleCount = (uint)(_companions.Count(x => x.Gender == Enums.Gender.Male) + (principal.Gender == Enums.Gender.Male ? 1 : 0));
            FemaleCount = (uint)(_companions.Count(x => x.Gender == Enums.Gender.Female) + (principal.Gender == Enums.Gender.Female ? 1 : 0));
            PrincipalId = principalId;
            CheckOverallAmount(MaleCount, FemaleCount);
            TimeOfEntrance = timeOfEntrance;
            TimeOfExit = timeOfExit;
            _companions = companions;
            Principal = principal;
        }
        public IEnumerable<Companion> Companions => _companions.AsReadOnly();

        public Guid PrincipalId { get; private set; }
        public IndividualPrincipal Principal { get; private set; }

        #region Validation
        private void CheckOverallAmount(uint maleCount, uint femaleCount)
        {
            var principalGender = Principal.Gender;
            if ((maleCount + femaleCount) > 5)
                throw new IndividualOverallCapacityException();
        }
        #endregion
    }
}
