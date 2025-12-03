using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class CompanionAlreadyExistsException : ValidationFailedDomainException
    {
        public CompanionAlreadyExistsException() : base("Companion Already Exists") { }
    }
}