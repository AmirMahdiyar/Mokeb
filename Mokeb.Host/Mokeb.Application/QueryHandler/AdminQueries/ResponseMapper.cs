using Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate;
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
    }
}
