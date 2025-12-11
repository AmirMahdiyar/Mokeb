using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;
using Mokeb.Domain.Model.ValueObjects;

namespace Mokeb.Domain.Model.Entities
{
    public class CaravanPrincipal : Principal
    {
        protected internal List<Pilgrim> _pilgrims = new List<Pilgrim>();
        private CaravanPrincipal() { } // For ef
        public CaravanPrincipal(string name, string familyName, string nationalCode,
            DateOnly dateOfBirth, Gender gender, string passportNumber, ContactInformation contactInformation, IdentityInformation identityInformation) :
            base(name, familyName, nationalCode, passportNumber, dateOfBirth, gender, contactInformation, identityInformation)
        {
        }
        public IEnumerable<Pilgrim> Pilgrims => _pilgrims.AsReadOnly();

        #region Behaviors
        public void AddPilgrim(Pilgrim pilgrim)
        {
            if (_pilgrims.Contains(pilgrim))
                throw new ThisPilgrimAlreadyExistException();
            _pilgrims.Add(pilgrim);
        }
        public void RemovePilgrim(Pilgrim pilgrim)
        {
            if (!_pilgrims.Contains(pilgrim))
                throw new PilgrimNotFoundException();
            _pilgrims.Remove(pilgrim);
        }

        #endregion
    }
}
