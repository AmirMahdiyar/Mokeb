using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class NewDateIsEqualWithOldDateException : NoChangesDomainException
    {
        public NewDateIsEqualWithOldDateException() : base("New Date can't be equal with old date") { }
    }
}
