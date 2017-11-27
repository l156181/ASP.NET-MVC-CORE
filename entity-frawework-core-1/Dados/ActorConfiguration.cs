using System;
using System.Collections;
using System.Linq;
using Microsoft. EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using entity_frawework_core_1.Model;

namespace entity_frawework_core_1.Dados
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        void IEntityTypeConfiguration<Actor>.Configure(EntityTypeBuilder<Actor> builder)
        {
                 builder.ToTable("actor");

                 builder.HasIndex(e => e.LastName)
                    .HasName("idx_actor_last_name");

                 builder.Property(e => e.ActorId).HasColumnName("actor_id");

                 builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(45)                    
                    .IsUnicode(false);

                 builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                 builder.Property(e => e.LastUpdate)
                    .HasColumnName("last_update") 
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");        

                builder.HasIndex(a => a.LastName);

                builder.HasAlternateKey(a => new{a.FirstName, a.LastName});
                    
        }
    }
}