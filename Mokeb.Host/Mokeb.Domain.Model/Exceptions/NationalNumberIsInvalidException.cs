using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class NationalNumberIsInvalidException : ValidationFailedDomainException
    {
        public NationalNumberIsInvalidException() : base("National Number Can't Be Empty And It's Length Should be 10") { }
    }
}