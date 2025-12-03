using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class FamilyNameIsInvalidException : ValidationFailedDomainException
    {
        public FamilyNameIsInvalidException() : base("FamilyName Can't Be Empty") { }
    }
}