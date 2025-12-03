using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class AnswerIsInvalidException : ValidationFailedDomainException
    {
        public AnswerIsInvalidException() : base("Answer Can't be null or empty") { }
    }
}