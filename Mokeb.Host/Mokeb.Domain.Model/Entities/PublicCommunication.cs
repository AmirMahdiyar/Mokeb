using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;
using Mokeb.Domain.Model.ValueObjects;
using System.Text.RegularExpressions;

namespace Mokeb.Domain.Model.Entities
{
    public class PublicCommunication : BaseEntity<Guid>
    {
        private PublicCommunication() { } //For ef
        public PublicCommunication(string phoneNumber, Address iranAddress, Address mokebAddress)
        {
            CheckPhoneNumber(phoneNumber);

            PhoneNumber = phoneNumber;
            IranAddress = iranAddress;
            MokebAddress = mokebAddress;
        }
        private PublicCommunication() { } // For ef
        public string PhoneNumber { get; private set; }
        public Address IranAddress { get; private set; }
        public Address MokebAddress { get; private set; }


        #region Validations
        public void CheckPhoneNumber(string phoneNumber)
        {
            var pattern = @"^09\d{9}$";
            if (string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, pattern))
                throw new PhoneNumberIsInvalidException();
        }
        #endregion
    }
}
