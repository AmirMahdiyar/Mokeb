using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions;
using System.Text.RegularExpressions;

namespace Mokeb.Domain.Model.Entities
{
    public class Pilgrim : BaseEntity<Guid>
    {
        public Pilgrim(string name, string familyName, string nationalNumber, DateOnly dateOfBirth, string phoneNumber, Gender gender, string passportNumber)
        {
            CheckName(name);
            CheckFamilyName(familyName);
            CheckNationalNumber(nationalNumber);
            CheckPassportNumber(passportNumber);
            CheckPhoneNumber(phoneNumber);

            Id = Guid.NewGuid();
            Name = name;
            FamilyName = familyName;
            NationalNumber = nationalNumber;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Gender = gender;
            PassportNumber = passportNumber;
        }

        private Pilgrim() { } // For ef
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public string NationalNumber { get; private set; }
        public string PassportNumber { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }


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
        public void CheckNationalNumber(string nationalNumber)
        {
            var pattern = @"^\d{10}$";
            if (string.IsNullOrWhiteSpace(nationalNumber) || !Regex.IsMatch(nationalNumber, pattern))
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
