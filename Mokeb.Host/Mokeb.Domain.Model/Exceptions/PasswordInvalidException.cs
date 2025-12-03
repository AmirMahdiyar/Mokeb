using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class PasswordInvalidException : ValidationFailedDomainException
    {
        public PasswordInvalidException() : base("Password Is Invalid")
        {
        }
    }
}