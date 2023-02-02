using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //Entity için entityKey, tablo için primaryKey tanımı yapılır.
            builder.HasKey(x => x.Id);

            //Belirlenen entityKey/primaryKey otomatik olarak belirlenecek şekilde ayarlanır.
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=>x.Active).IsRequired().HasDefaultValue(true);
            builder.Property(x=>x.Deleted).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CreateTime).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdateTime).IsRequired(false);
            builder.Property(x => x.DeleteTime).IsRequired(false);

            //Belirlenen field/sütun ayarları yapılır.
            builder.Property(x => x.Prefix).IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Middlename).IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Suffix).IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired();

            //Bir entity/tablonun başka bir entity/tabloya nasıl bağlandığını belirler.
            builder.HasOne(x => x.Department).WithMany(x => x.People).HasForeignKey(x => x.DepartmentId);

            //Bu entity hangi tabloyla ve şemayla konuşuyor.
            builder.ToTable("Person", "HR");
        }
    }
}
