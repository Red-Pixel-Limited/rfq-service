namespace RFQ.Repository.Mappings
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class AttributeMap : ClassMap<Attribute>
    {
        public AttributeMap()
        {
            Table("Attribute");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.Value).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.DisplayName).Nullable().Length(SqlTranslator.VarcharMax);
            References(x => x.Configuration).Not.Nullable().Column("Filter_Id");
        }
    }
}
