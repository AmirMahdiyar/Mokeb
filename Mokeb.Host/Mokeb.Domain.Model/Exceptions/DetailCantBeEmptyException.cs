using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class DetailCantBeEmptyException : ValidationFailedDomainException
    {
        public DetailCantBeEmptyException() : base("Details cant be empty !") { }
    }
}