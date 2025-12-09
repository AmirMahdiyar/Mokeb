using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate
{
    public class GettingAcceptedRequestsByDateQueryResponse
    {
        public static GettingAcceptedRequestsByDateQueryResponse SucceededResponse(List<GettingAcceptedRequestsResponseDto> response)
        {
            return new GettingAcceptedRequestsByDateQueryResponse()
            {
                Response = response,
            };
        }

        public List<GettingAcceptedRequestsResponseDto> Response { get; set; }
    }
    public class GettingAcceptedRequestsResponseDto
    {
        public GettingAcceptedRequestsResponseDto(string fullName, uint maleCount, uint femaleCount, DateOnly exitDate, IEnumerable<Travelers> travelers)
        {
            FullName = fullName;
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            ExitDate = exitDate;
            Travelers = travelers;
        }

        public string FullName { get; set; }
        public uint MaleCount { get; set; }
        public uint FemaleCount { get; set; }
        public uint OverallCount => MaleCount + FemaleCount;
        public string PrincipalType => OverallCount > 5 ? "Caravan" : "Individual";
        public DateOnly ExitDate { get; set; }
        public IEnumerable<Travelers> Travelers { get; set; }
    }
}
