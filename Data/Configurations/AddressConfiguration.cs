using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Active).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.Deleted).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CreateTime).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdateTime).IsRequired(false);
            builder.Property(x => x.DeleteTime).IsRequired(false);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
            builder.Property(x => x.City).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Detail).IsRequired(false).HasMaxLength(250);

            builder.HasOne(x => x.Person).WithMany(x => x.Addresses).HasForeignKey(x => x.PersonId);
            builder.ToTable("Address", "HR");
        }
    }
}
