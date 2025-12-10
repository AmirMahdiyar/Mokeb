using Mokeb.Domain.Model.Enums;

namespace Mokeb.Application.Dtos
{
    public class RoomAvailabilityDto
    {
        public RoomAvailabilityDto(DateOnly date, uint emptyCapacity, Gender gender, uint overallCapacity, uint reservedAmount)
        {
            Date = date;
            EmptyCapacity = emptyCapacity;
            Gender = gender;
            OverallCapacity = overallCapacity;
            ReservedAmount = reservedAmount;
        }

        public DateOnly Date { get; set; }
        public uint OverallCapacity { get; set; }
        public uint ReservedAmount { get; set; }
        public uint EmptyCapacity { get; set; }
        public Gender Gender { get; set; }
        public string ReserveStatus => EmptyCapacity == 0 ? "Full" : "Limited";
    }
}
