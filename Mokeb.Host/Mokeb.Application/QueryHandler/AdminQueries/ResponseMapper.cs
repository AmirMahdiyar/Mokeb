using Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate;
using Mokeb.Application.QueryHandler.AdminQueries.GettingCaravanInformation;
using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.QueryHandler.AdminQueries
{
    public static class ResponseMapper
    {
        public static List<GettingAcceptedRequestsResponseDto> ToGettingAcceptedRequestResponseDto(this List<Request> requests)
        {
            var result = new List<GettingAcceptedRequestsResponseDto>();
            foreach (var request in requests)
            {
                result.Add(new GettingAcceptedRequestsResponseDto(request.Travelers.First().Name + " " + request.Travelers.First().FamilyName,
                   request.MaleCount, request.FemaleCount, DateOnly.FromDateTime(request.ExitTime), request.Travelers));
            }
            return result;
        }
        public static PrincipalDto ToPrincipalDto(this Principal principal)
        {
            return new PrincipalDto(principal.Name, principal.FamilyName, principal.NationalCode, principal.PassportNumber
                                    , principal.DateOfBirth, principal.Gender, principal.ContactInformation.Gmail
                                    , principal.ContactInformation.PhoneNumber, principal.ContactInformation.EmergencyPhoneNumber);
        }
    }
}
