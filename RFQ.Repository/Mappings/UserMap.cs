namespace RFQ.Repository.Mappings
{
    using FluentNHibernate.Mapping;
    using Core.Entities;

    public sealed class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("User");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Username).Not.Nullable().Length(256);
            Map(x => x.Name).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.Surname).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.Initials).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.DefaultEmail).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.DefaultPhone).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.FusionId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ExternalId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.VenueId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ProductId).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.LastLoggedIn).Nullable().Column("LastLoginDate");
            Map(x => x.LastLoggedOut).Nullable().Column("LastLogoutDate");
            Map(x => x.Created).Nullable().Column("CreateDate");
            Map(x => x.LastModified).Nullable().Column("ModifyDate");
            Map(x => x.CreatedBy).Nullable().Length(SqlTranslator.VarcharMax);
            Map(x => x.ModifiedBy).Nullable().Length(SqlTranslator.VarcharMax);
            References(x => x.Organization).Not.Nullable().Column("FirmId");
            HasMany(x => x.Quotes).Cascade.All();
            HasMany(x => x.RFQOffers).Cascade.All();
        }
    }
}
