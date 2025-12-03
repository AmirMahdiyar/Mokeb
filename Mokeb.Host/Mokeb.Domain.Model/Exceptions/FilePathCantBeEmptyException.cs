using Mokeb.Common.Base.DomainExceptions;

namespace Mokeb.Domain.Model.Exceptions
{
    public class FilePathCantBeEmptyException : ValidationFailedDomainException
    {
        public FilePathCantBeEmptyException() : base("FilePath cant be empty !") { }
    }
}