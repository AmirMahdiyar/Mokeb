using Mokeb.Domain.Model.Entities;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;

namespace Mokeb.Domain.Model.States
{
    public class DelayInEntranceState : ConvoyState
    {
        public override void AddPilgrim(Pilgrim pilgrim)
        {
            throw new ConvoyIsNotAllowedException();
        }

        public override void RemovePilgrim(Pilgrim pilgrim)
        {
            throw new ConvoyIsNotAllowedException();
        }
    }
}
