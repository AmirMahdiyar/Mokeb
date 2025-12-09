using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CompanionExceptions;
using Mokeb.Domain.Model.ValueObjects;

namespace Mokeb.Domain.Model.Entities
{
    public class IndividualPrincipal : Principal
    {
        private List<Companion> _companion = new List<Companion>();
        private IndividualPrincipal() { } // For ef
        public IndividualPrincipal(string name, string familyName, string nationalCode,
            DateOnly dateOfBirth, Gender gender, string passportNumber, ContactInformation contactInformation, IdentityInformation identityInformation)
        {
            CheckName(name);
            CheckFamilyName(familyName);
            CheckNationalCode(nationalCode);
            CheckPassportNumber(passportNumber);


            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            NationalCode = nationalCode;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PassportNumber = passportNumber;
            ContactInformation = contactInformation;
            IdentityInformation = identityInformation;
        }

        public IEnumerable<Companion> Companion => _companion.AsReadOnly();

        #region Behaviors
        public void AddCompanion(Companion companion)
        {
            if (_companion.Any(x => x == companion))
                throw new CompanionAlreadyExistsException();
            _companion.Add(companion);
        }
        public void RemoveCompanion(Companion companion)
        {
            if (!_companion.Any(x => x == companion))
                throw new CompanionNotFoundException();
            _companion.Remove(companion);
        }
        #endregion

    }

}
