using Mokeb.Common.Base.DomainExceptions.BaseException;

namespace Mokeb.Common.Base.DomainExceptions
{
    public class NotChangesDomainException : DomainException
    {
        public NotChangesDomainException()
        {
        }

        public NotChangesDomainException(string? message) : base(message)
        {
        }

        public NotChangesDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
