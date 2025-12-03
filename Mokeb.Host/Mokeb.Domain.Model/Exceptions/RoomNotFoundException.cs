using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class RoomNotFoundException : ObjectNotFoundDomainException
    {
        public RoomNotFoundException() : base("Room Not Found !") { }
    }
}