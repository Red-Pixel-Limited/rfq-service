namespace RFQ.Communication.DTOs
{
    public sealed class InstrumentAttributeDTO
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public InstrumentAttributeDTO(string name, string value)
        {
            Value = value;
            Name = name;
        }
    }
}
