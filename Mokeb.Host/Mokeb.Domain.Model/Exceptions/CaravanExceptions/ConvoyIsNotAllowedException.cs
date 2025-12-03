using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions.CaravanExceptions
{
    public class ConvoyIsNotAllowedException : NotAllowedDomainException
    {
        public ConvoyIsNotAllowedException() : base("Convoy Is not allowed in this state")
        {
        }
    }
}
