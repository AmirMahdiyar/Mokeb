using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class ThisConvoyAlreadyHasThisRoomException : ObjectAlreadyExistDomainException
    {
        public ThisConvoyAlreadyHasThisRoomException() : base("This Convoy Has This Room !") { }
    }
}