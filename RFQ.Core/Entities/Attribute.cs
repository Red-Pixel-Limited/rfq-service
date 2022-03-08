namespace RFQ.Core.Entities
{
    public class Attribute : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual InstrumentConfiguration Configuration { get; set; }
    }
}
