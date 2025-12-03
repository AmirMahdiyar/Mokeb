using Mokeb.Domain.Model.Entities;

namespace Mokeb.Domain.Model.States
{
    public abstract class ConvoyState
    {
        protected ConvoyPrincipal _principal;
        public void SetConvoy(ConvoyPrincipal principal)
        {
            _principal = principal;
        }
        public abstract void AddPilgrim(Pilgrim pilgrim);
        public abstract void RemovePilgrim(Pilgrim pilgrim);

    }
}
