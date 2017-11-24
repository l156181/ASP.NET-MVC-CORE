using System;
using System.Collections;
using System.Linq;
using Microsoft. EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using entity_frawework_core_1.Model;

namespace entity_frawework_core_1.Dados
{
    public class FilmActorConfiguration : IEntityTypeConfiguration<FilmActor>
    {
        void IEntityTypeConfiguration<FilmActor>.Configure(EntityTypeBuilder<FilmActor> builder)
        {
             
            builder.HasKey(e => new { e.ActorId, e.FilmId })
                .ForSqlServerIsClustered(false);

            builder.ToTable("film_actor");

            builder.HasIndex(e => e.ActorId)
                .HasName("idx_fk_film_actor_actor");

            builder.HasIndex(e => e.FilmId)
                .HasName("idx_fk_film_actor_film");

            builder.Property(e => e.ActorId).HasColumnName("actor_id");

            builder.Property(e => e.FilmId).HasColumnName("film_id");

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Actor)
                .WithMany(p => p.FilmActor)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_actor_actor");

            builder.HasOne(d => d.Film)
                .WithMany(p => p.FilmActor)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_actor_film");


             // Build a composite key 
             // builder.HasKey("key 1","key 2");   
        }
    }
}