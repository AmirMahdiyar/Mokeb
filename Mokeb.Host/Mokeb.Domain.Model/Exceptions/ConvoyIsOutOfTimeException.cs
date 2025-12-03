using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class ConvoyIsOutOfTimeException : NotAllowedDomainException
    {
        public ConvoyIsOutOfTimeException() : base("Convoy Is Out Of ProcessTime")
        {
        }
    }
}