namespace RFQ.Repository.Mappings
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class InstrumentConfigurationMap : ClassMap<InstrumentConfiguration>
    {
        public InstrumentConfigurationMap()
        {
            Table("Filter");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.RequestTimerDefault).Nullable();
            Map(x => x.RequestTimerMinimum).Nullable();
            Map(x => x.RequestTimerMaximum).Nullable();
            Map(x => x.ResponseTimerDefault).Nullable();
            Map(x => x.ResponseTimerMinimum).Nullable();
            Map(x => x.ResponseTimerMaximum).Nullable();
            Map(x => x.MinimumNumOfMarketMakers).Nullable();
            Map(x => x.DefaultSize).Nullable();
            Map(x => x.MinimumSize).Column("MinSize").Nullable();
            Map(x => x.MaximumSize).Column("MaxSize").Nullable();
            Map(x => x.IsAnonymous).Not.Nullable();
            Map(x => x.IsMultipleExecutionAllowed).Not.Nullable().Column("AllowMultiExecute");
            Map(x => x.ShouldTradeByVWAP).Not.Nullable().Column("VWAP");
            Map(x => x.ShouldTradeByAON).Not.Nullable().Column("AON");
            Map(x => x.ClearingType).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ConfigurationType).Nullable().Column("FilterType");
            Map(x => x.RuleLevel).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.OrderRule).Not.Nullable();
            Map(x => x.Magnitude).Not.Nullable().Length(100);
            Map(x => x.TradeDisclosureToMissedResponders).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.TradeDisclosureToMarketData).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.InstrumentSizeValidationRules).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.Created).Nullable().Column("CreateDate");
            Map(x => x.LastModified).Nullable().Column("ModifyDate");
            Map(x => x.CreatedBy).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ModifiedBy).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.VenueId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ProductId).Nullable().Length(SqlTranslator.VarcharMax);
            HasMany(x => x.Attributes).Cascade.All();
            HasMany(x => x.Adjustments).Cascade.All();
        }
    }
}
