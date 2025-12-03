using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class ThisUserIsInThisRoomException : ObjectAlreadyExistDomainException
    {
        public ThisUserIsInThisRoomException() : base("This User Is Already In This Room") { }
    }
}