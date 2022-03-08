namespace RFQ.Repository.Mappings 
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class OrganizationMap : ClassMap<Organization>
    {
        public OrganizationMap()
        {
            Table("Firm");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.MISCode).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.HitRatio).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.SuccessfulExecution).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.TotalRequest).Not.Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ExternalId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.VenueId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ProductId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.Created).Nullable().Column("CreateDate");
            Map(x => x.LastModified).Nullable().Column("ModifyDate");
            Map(x => x.CreatedBy).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ModifiedBy).Nullable().Length(SqlTranslator.VarcharMax);
            HasMany(x => x.Users).Cascade.All();
            HasMany(x => x.ConfigurationDetails).Cascade.All();
        }
    }
}
