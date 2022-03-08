namespace RFQ.Repository.Mappings
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class RFQOfferMap : ClassMap<RFQOffer>
    {
        public RFQOfferMap()
        {
            Table("RFQSession");
            Id(x => x.Id).Not.Nullable().Length(32);
            Map(x => x.Size).Not.Nullable();
            Map(x => x.SizeBase).Not.Nullable();
            Map(x => x.Side).Not.Nullable();
            Map(x => x.State).Not.Nullable().Column("CurrentState");
            Map(x => x.Created).Not.Nullable().Column("CreationDate");
            Map(x => x.LastModified).Nullable().Column("LastModifyDate");
            Map(x => x.VenueId).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ProductId).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.InstrumentId).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.InstrumentName).Not.Nullable().Length(SqlTranslator.VarcharMax);
            References(x => x.Owner).Not.Nullable().Column("UserId");
            HasMany(x => x.Quotes).Cascade.All();
        }
    }
}
