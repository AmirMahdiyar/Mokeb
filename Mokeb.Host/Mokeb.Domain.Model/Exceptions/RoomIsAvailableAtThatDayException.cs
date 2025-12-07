using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class RoomIsAvailableAtThatDayException : ObjectAlreadyExistDomainException
    {
        public RoomIsAvailableAtThatDayException() : base("room is available at that day") { }
    }
}