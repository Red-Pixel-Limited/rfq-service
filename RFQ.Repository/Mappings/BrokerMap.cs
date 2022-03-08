namespace RFQ.Repository.Mappings
{
    using Core.Entities;
    using FluentNHibernate.Mapping;

    public sealed class BrokerMap : ClassMap<Broker>
    {
        public BrokerMap()
        {
            Table("GRSP");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IBUsername).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.IBPassword).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.CanAutoConnect).Nullable().Column("IsAutoConnect");
            Map(x => x.Notes).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.VenueId).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ProductId).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.Created).Nullable().Column("CreateDate");
            Map(x => x.LastModified).Nullable().Column("ModifyDate");
            Map(x => x.CreatedBy).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ModifiedBy).Nullable().Length(SqlTranslator.VarcharMax);
        }
    }
}
