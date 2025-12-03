using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CompanionExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class IndividualPrincipal : Principal
    {
        private const Role role = Role.Individual;
        private List<Companion> _companion = new List<Companion>();
        private IndividualPrincipal() { } // For ef
        public IndividualPrincipal(string name, string familyName, string nationalNumber, string gmail,
            string phoneNumber, string emergencyPhoneNumber, DateOnly dateOfBirth,
            Gender gender, string passportNumber, string username, string password)
        {
            CheckName(name);
            CheckFamilyName(familyName);
            CheckNationalNumber(nationalNumber);
            CheckGmail(gmail);
            CheckPassportNumber(passportNumber);
            CheckPhoneNumber(phoneNumber);
            CheckPhoneNumber(emergencyPhoneNumber);
            CheckUsername(username);
            CheckPassword(password);

            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            NationalNumber = nationalNumber;
            Gmail = gmail;
            PhoneNumber = phoneNumber;
            EmergencyPhoneNumber = emergencyPhoneNumber;
            DateOfBirth = dateOfBirth;
            Role = role;
            Gender = gender;
            PassportNumber = passportNumber;
            Username = username;
            Password = password;
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
