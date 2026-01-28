using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Dtos
{
    public record RequestDto
    {
        public RequestDto(DateOnly enterTime, DateOnly exitTime, int travelersAmount, IEnumerable<Travelers> travelers)
        {
            EnterTime = enterTime;
            ExitTime = exitTime;
            TravelersAmount = travelersAmount;
            Travelers = travelers;
        }
        public DateOnly EnterTime { get; set; }
        public DateOnly ExitTime { get; set; }
        public int TravelersAmount { get; set; }
        public IEnumerable<Travelers> Travelers { get; set; }
    }
}
