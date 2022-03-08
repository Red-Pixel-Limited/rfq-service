namespace RFQ.Repository.Mappings
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class QuoteMap : ClassMap<Quote>
    {
        public QuoteMap()
        {
            Table("MarketMakerQuote");
            Id(x => x.Id).Not.Nullable().Length(32);
            Map(x => x.SellPrice).Nullable();
            Map(x => x.SellPriceBase).Nullable();
            Map(x => x.BuyPrice).Nullable();
            Map(x => x.BuyPriceBase).Nullable();
            Map(x => x.State).Not.Nullable().Column("CurrentState");
            Map(x => x.Created).Not.Nullable().Column("CreationDate");
            Map(x => x.LastModified).Nullable().Column("LastModifyDate");
            References(x => x.Owner).Not.Nullable().Column("UserId");
            References(x => x.RFQ).Not.Nullable().Column("RFQSessionId");
        }
    }
}
