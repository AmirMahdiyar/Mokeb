using Mokeb.Domain.Model.Enums;

namespace Mokeb.Application.Dtos
{
    public class RequestedRequestsDto
    {
        public RequestedRequestsDto(string name, string familyName, string phoneNumber, uint maleCount, uint femaleCount,
                    DateOnly enterTime, DateOnly exitTime, Guid requestId, State requestState)
        {
            Name = name;
            FamilyName = familyName;
            PhoneNumber = phoneNumber;
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            EnterTime = enterTime;
            ExitTime = exitTime;
            RequestId = requestId;
            RequestState = requestState;
        }

        public Guid RequestId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string FullName => Name + FamilyName;
        public string PhoneNumber { get; set; }
        public uint MaleCount { get; set; }
        public uint FemaleCount { get; set; }
        public uint OverallCount => MaleCount + FemaleCount;
        public DateOnly EnterTime { get; set; }
        public DateOnly ExitTime { get; set; }
        public State RequestState { get; set; }
    }
}
