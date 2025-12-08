
using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class RoomIsAvailableAtThatDayException : ObjectAlreadyExistDomainException
    {
        public RoomIsAvailableAtThatDayException() : base("Room Is Available At that day") { }
    }
}