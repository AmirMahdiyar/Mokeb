using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class TitleCantBeEmptyException : ValidationFailedDomainException
    {
        public TitleCantBeEmptyException() : base("Title can't be empty !") { }
    }
}