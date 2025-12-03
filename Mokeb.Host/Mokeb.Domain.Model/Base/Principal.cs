using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;
using System.Text.RegularExpressions;

namespace Mokeb.Domain.Model.Base
{
    public abstract class Principal : BaseEntity<Guid>
    {
        public string Name { get; protected set; }
        public string FamilyName { get; protected set; }
        public string NationalNumber { get; protected set; }
        public string Gmail { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string EmergencyPhoneNumber { get; protected set; }
        public DateOnly DateOfBirth { get; protected set; }
        public Role Role { get; protected set; }
        public Gender Gender { get; protected set; }
        public string PassportNumber { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }



        #region Behaviors
        public void ChangeName(string name)
        {
            CheckName(name);
            Name = name;
        }
        public void ChangeFamilyName(string familyName)
        {
            CheckFamilyName(familyName);
            FamilyName = familyName;
        }
        public void ChangeNationalNumber(string nationalNumber)
        {
            CheckNationalNumber(nationalNumber);
            NationalNumber = nationalNumber;
        }
        public void ChangeGmail(string gmail)
        {
            CheckGmail(gmail);
            Gmail = gmail;
        }
        public void ChangePhoneNumber(string phoneNumber)
        {
            CheckPhoneNumber(phoneNumber);
            PhoneNumber = phoneNumber;
        }
        public void ChangeEmergencyPhoneNumber(string emergencyPhoneNumber)
        {
            CheckPhoneNumber(emergencyPhoneNumber);
            EmergencyPhoneNumber = emergencyPhoneNumber;
        }
        public void ChangeDateOfBirth(DateOnly dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
        public void ChangeGender(Gender gender)
        {
            Gender = gender;
        }
        public void ChangePassportNumber(string passportNumber)
        {
            CheckPassportNumber(passportNumber);
            PassportNumber = passportNumber;
        }
        public void ChangeUsername(string username)
        {
            CheckUsername(username);
            Username = username;
        }
        public void ChangePassword(string password)
        {
            CheckPassword(password);
            Password = password;
        }
        #endregion
        #region Validations
        public void CheckUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new UsernameIsInvalidException();
        }

        public void CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordInvalidException();
        }

        public void CheckGmail(string gmail)
        {
            var pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            if (string.IsNullOrWhiteSpace(gmail) || !Regex.IsMatch(gmail, pattern))
            {
                throw new GmailIsInvalidException();
            }
        }
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
