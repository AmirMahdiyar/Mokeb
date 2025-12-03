using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class GmailIsInvalidException : ValidationFailedDomainException
    {
        public GmailIsInvalidException() : base("Gmail Is invalid") { }
    }
}
