using Mokeb.Domain.Model.Enums;

namespace Mokeb.Application.Dtos
{
    public record AcceptedRequestDto
    {
        public AcceptedRequestDto(Guid id, DateOnly enterTime, DateOnly exitTime, State state)
        {
            Id = id;
            EnterTime = enterTime;
            ExitTime = exitTime;
            State = state;
        }

        public Guid Id { get; set; }
        public DateOnly EnterTime { get; set; }
        public DateOnly ExitTime { get; set; }
        public State State { get; set; }
        public string StringState => State == State.Accepted ? "تایید شده" : "در انتظار تایید";
    }
}
