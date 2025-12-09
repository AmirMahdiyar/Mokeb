using Mokeb.Domain.Model.Enums;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingCaravanInformation
{
    public class GettingPrincipalInformationQueryResponse
    {
        public static GettingPrincipalInformationQueryResponse Response(PrincipalDto principal)
        {
            return new GettingPrincipalInformationQueryResponse() { Principal = principal };
        }
        public PrincipalDto Principal { get; set; }
    }
    public class PrincipalDto
    {
        public PrincipalDto(string name, string familyName, string nationalCode, string passportNumber, DateOnly dateOfBirth, Gender gender, string gmail, string phoneNumber, string emergencyPhoneNumber)
        {
            Name = name;
            FamilyName = familyName;
            NationalCode = nationalCode;
            PassportNumber = passportNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender.ToString();
            Gmail = gmail;
            PhoneNumber = phoneNumber;
            EmergencyPhoneNumber = emergencyPhoneNumber;
        }

        public string Name { get; protected set; }
        public string FamilyName { get; protected set; }
        public string NationalCode { get; protected set; }
        public string PassportNumber { get; protected set; }
        public DateOnly DateOfBirth { get; protected set; }
        public string Gender { get; protected set; }
        public string Gmail { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string EmergencyPhoneNumber { get; protected set; }
    }
}
