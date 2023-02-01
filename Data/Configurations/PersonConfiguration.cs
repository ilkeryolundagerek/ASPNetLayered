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

            //Belirlenen field/sütun ayarları yapılır.
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Middlename).IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired();

            //Bir entity/tablonun başka bir entity/tabloya nasıl bağlandığını belirler.
            builder.HasOne(x => x.Department).WithMany(x => x.People).HasForeignKey(x => x.DepartmentId);

            //Bu entity hangi tabloyla ve şemayla konuşuyor.
            builder.ToTable("Person", "HR");
        }
    }
}
