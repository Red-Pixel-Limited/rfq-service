namespace RFQ.Core.Artifacts
{
    public sealed class Instrument
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Instrument(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
