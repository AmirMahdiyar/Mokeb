using Mokeb.Domain.Model.Entities;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;

namespace Mokeb.Domain.Model.States
{
    public class InProcessState : ConvoyState
    {
        public override void AddPilgrim(Pilgrim pilgrim)
        {
            InProcessCondition();
            _principal._pilgrims.Add(pilgrim);
        }
        public override void RemovePilgrim(Pilgrim pilgrim)
        {
            InProcessCondition();
            _principal._pilgrims.Remove(pilgrim);
        }

        private void InProcessCondition()
        {
            if (_principal.EstimatedTimeForAddingPilgrims < DateTime.Now)
            {
                _principal.ChangeStateToDone();
                _principal.Requests.LastOrDefault().ChangeToDone();
                throw new ConvoyIsOutOfTimeException();
            }
        }

    }
}
