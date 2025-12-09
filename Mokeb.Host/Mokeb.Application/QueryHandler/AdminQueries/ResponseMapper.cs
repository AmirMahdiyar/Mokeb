using Mokeb.Application.Dtos;
using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.QueryHandler.AdminQueries
{
    public static class ResponseMapper
    {
        public static List<GettingIncomingOrAcceptedRequestsResponseDto> ToGettingAcceptedRequestResponseDto(this List<Request> requests)
        {
            var result = new List<GettingIncomingOrAcceptedRequestsResponseDto>();
            foreach (var request in requests)
            {
                result.Add(new GettingIncomingOrAcceptedRequestsResponseDto(request.Travelers.First().Name + " " + request.Travelers.First().FamilyName,
                   request.MaleCount, request.FemaleCount, DateOnly.FromDateTime(request.ExitTime), request.Travelers));
            }
            return result;
        }
        public static List<GettingOutGoingOrAcceptedRequestsResponseDto> ToGettingOutGoingOrAcceptedRequestResponseDto(this List<Request> requests)
        {
            var result = new List<GettingOutGoingOrAcceptedRequestsResponseDto>();
            foreach (var request in requests)
            {
                result.Add(new GettingOutGoingOrAcceptedRequestsResponseDto(request.Travelers.First().Name + " " + request.Travelers.First().FamilyName,
                   request.MaleCount, request.FemaleCount, DateOnly.FromDateTime(request.EnterTime), request.Travelers));
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
