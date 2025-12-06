namespace Mokeb.Domain.Model.ValueObjects
{
    public class RequestRoom
    {
        public RequestRoom(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public uint Id { get; private set; }
        public string Name { get; private set; }
    }
}
