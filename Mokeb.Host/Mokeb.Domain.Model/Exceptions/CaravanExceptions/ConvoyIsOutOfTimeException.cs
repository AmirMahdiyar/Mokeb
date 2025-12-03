using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions.CaravanExceptions
{
    public class ConvoyIsOutOfTimeException : NotAllowedDomainException
    {
        public ConvoyIsOutOfTimeException() : base("Convoy Is Out Of ProcessTime")
        {
        }
    }
}