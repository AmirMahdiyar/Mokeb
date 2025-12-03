using Mokeb.Domain.Model.Base;

namespace Mokeb.Domain.Model.Entities
{
    public class PublicCommunication : BaseEntity<Guid>
    {
        public string PhoneNumber { get; private set; }
        public Address IranAddress { get; private set; }
        public Address MokebAddress { get; private set; }

    }
}
