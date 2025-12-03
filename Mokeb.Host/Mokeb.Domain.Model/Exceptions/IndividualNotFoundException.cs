using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class IndividualNotFoundException : ObjectNotFoundDomainException
    {
        public IndividualNotFoundException() : base("Individual Not Found") { }
    }
}