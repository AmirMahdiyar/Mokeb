using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class AreaCantBeEmptyException : ValidationFailedDomainException
    {
        public AreaCantBeEmptyException() : base("Area Name can't be null or empty") { }
    }
}