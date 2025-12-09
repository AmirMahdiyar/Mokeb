using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;
using System.Text.RegularExpressions;

namespace Mokeb.Domain.Model.Entities
{
    public class Companion : BaseEntity<Guid>
    {
        public Companion(string name, string familyName, string nationalCode, DateOnly dateOfBirth, string phoneNumber, Gender gender, string passportNumber, Guid principalId)
        {
            CheckName(name);
            CheckFamilyName(familyName);
            CheckNationalCode(nationalCode);
            CheckPassportNumber(passportNumber);
            CheckPhoneNumber(phoneNumber);

            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            NationalCode = nationalCode;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Gender = gender;
            PassportNumber = passportNumber;
            PrincipalId = principalId;
        }

        private Companion() { } // For ef
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public string NationalCode { get; private set; }
        public string PassportNumber { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }


        public Guid PrincipalId { get; private set; }


        #region Validations
        public void CheckPhoneNumber(string phoneNumber)
        {
            var pattern = @"^09\d{9}$";
            if (string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, pattern))
                throw new PhoneNumberIsInvalidException();
        }
        public void CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NameIsInvalidException();
        }
        public void CheckFamilyName(string familyName)
        {
            if (string.IsNullOrWhiteSpace(familyName))
                throw new FamilyNameIsInvalidException();
        }
        public void CheckNationalCode(string nationalCode)
        {
            var pattern = @"^\d{10}$";
            if (string.IsNullOrWhiteSpace(nationalCode) || !Regex.IsMatch(nationalCode, pattern))
                throw new NationalNumberIsInvalidException();
        }
        public void CheckPassportNumber(string passportNumber)
        {
            if (string.IsNullOrWhiteSpace(passportNumber))
                throw new PassportNumberIsInvalidException();
        }
        #endregion
    }
}
