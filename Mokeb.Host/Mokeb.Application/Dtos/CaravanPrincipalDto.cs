namespace Mokeb.Application.Dtos
{
    public class CaravanPrincipalDto
    {
        public CaravanPrincipalDto(string name, string familyName, string phoneNumber, uint maleCapacity, uint femaleCapacity, IEnumerable<PilgrimDto> travelers)
        {
            Name = name;
            FamilyName = familyName;
            PhoneNumber = phoneNumber;
            MaleCapacity = maleCapacity;
            FemaleCapacity = femaleCapacity;
            Travelers = travelers;
        }

        public string Name { get; protected set; }
        public string FamilyName { get; protected set; }
        public string FullName => Name + " " + FamilyName;
        public string PhoneNumber { get; protected set; }
        public uint MaleCapacity { get; protected set; }
        public uint FemaleCapacity { get; protected set; }
        public uint CaravanCapacity => MaleCapacity + FemaleCapacity;
        public IEnumerable<PilgrimDto> Travelers { get; protected set; }

    }
}
