using System;
using System.Collections;
using System.Linq;
using Microsoft. EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using entity_frawework_core_1.Model;

namespace entity_frawework_core_1.Dados
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        void IEntityTypeConfiguration<Language>.Configure(EntityTypeBuilder<Language> builder)
        {   
            builder.ToTable("language");

            builder.Property(e => e.LanguageId)
                .HasColumnName("language_id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("char(20)");
        }
    }
}