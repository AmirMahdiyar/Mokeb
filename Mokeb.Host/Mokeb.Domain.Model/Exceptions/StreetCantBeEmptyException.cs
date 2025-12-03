using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class StreetCantBeEmptyException : ValidationFailedDomainException
    {
        public StreetCantBeEmptyException() : base("Street Name can't be null or empty") { }
    }
}