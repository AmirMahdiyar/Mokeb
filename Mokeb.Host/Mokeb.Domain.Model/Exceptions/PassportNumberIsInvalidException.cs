using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class PassportNumberIsInvalidException : ValidationFailedDomainException
    {
        public PassportNumberIsInvalidException() : base("Passport Number Can't Be Empty") { }
    }
}