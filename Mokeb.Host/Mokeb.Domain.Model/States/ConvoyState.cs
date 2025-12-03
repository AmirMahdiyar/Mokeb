using Mokeb.Domain.Model.Entities;

namespace Mokeb.Domain.Model.States
{
    public abstract class ConvoyState
    {
        protected CaravanPrincipal _principal;
        public void SetConvoy(CaravanPrincipal principal)
        {
            _principal = principal;
        }
        public abstract void AddPilgrim(Pilgrim pilgrim);
        public abstract void RemovePilgrim(Pilgrim pilgrim);

    }
}
