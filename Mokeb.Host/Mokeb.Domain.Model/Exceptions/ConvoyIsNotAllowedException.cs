using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class ConvoyIsNotAllowedException : NotAllowedDomainException
    {
        public ConvoyIsNotAllowedException() : base("Convoy Is not allowed in this state")
        {
        }
    }
}
