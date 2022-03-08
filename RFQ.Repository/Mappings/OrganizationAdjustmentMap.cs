namespace RFQ.Repository.Mappings
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class OrganizationAdjustmentMap : ClassMap<OrganizationAdjustment>
    {
        public OrganizationAdjustmentMap()
        {
            Table("FilterFirm");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IsMarketMaker).Not.Nullable();
            Map(x => x.UserId).Nullable();
            Map(x => x.Created).Nullable().Column("CreateDate");
            Map(x => x.LastModified).Nullable().Column("ModifyDate");
            Map(x => x.CreatedBy).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ModifiedBy).Nullable().Length(SqlTranslator.VarcharMax);
            References(x => x.Configuration).Not.Nullable().ForeignKey("Filter_Id");
            References(x => x.Organization).Not.Nullable().ForeignKey("Firm_Id");
        }
    }
}
