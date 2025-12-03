using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    internal class PhoneNumberIsInvalidException : ValidationFailedDomainException
    {
        public PhoneNumberIsInvalidException() : base("PhoneNumber Is Invalid")
        {
        }
    }
}