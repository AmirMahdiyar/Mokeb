using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class NameIsInvalidException : ValidationFailedDomainException
    {
        public NameIsInvalidException() : base("Name Can't Be Empty")
        {
        }

    }
}