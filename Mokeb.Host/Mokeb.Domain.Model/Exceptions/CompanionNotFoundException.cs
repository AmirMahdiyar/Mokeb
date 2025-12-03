using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class CompanionNotFoundException : ValidationFailedDomainException
    {
        public CompanionNotFoundException() : base("Companion Not Found")
        {
        }
    }
}