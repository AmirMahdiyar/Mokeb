using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Dtos
{
    public class GettingOutGoingOrAcceptedRequestsResponseDto
    {
        public GettingOutGoingOrAcceptedRequestsResponseDto(string fullName, uint maleCount, uint femaleCount, DateOnly exitDate, IEnumerable<Travelers> travelers)
        {
            FullName = fullName;
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            EnterDate = exitDate;
            Travelers = travelers;
        }

        public string FullName { get; set; }
        public uint MaleCount { get; set; }
        public uint FemaleCount { get; set; }
        public uint OverallCount => MaleCount + FemaleCount;
        public string PrincipalType => OverallCount > 5 ? "Caravan" : "Individual";
        public DateOnly EnterDate { get; set; }
        public IEnumerable<Travelers> Travelers { get; set; }
    }
}
