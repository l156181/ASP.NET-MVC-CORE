using System;
using System.Collections;
using System.Linq;
using Microsoft. EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using entity_frawework_core_1.Model;


namespace entity_frawework_core_1.Dados
{
    public class FilmCategoryConfiguration : IEntityTypeConfiguration<FilmCategory>
    {
        void IEntityTypeConfiguration<FilmCategory>.Configure(EntityTypeBuilder<FilmCategory> builder)
        {
            builder.HasKey(e => new { e.FilmId, e.CategoryId })
                .ForSqlServerIsClustered(false);

            builder.ToTable("film_category");

            builder.HasIndex(e => e.CategoryId)
                .HasName("idx_fk_film_category_category");

            builder.HasIndex(e => e.FilmId)
                .HasName("idx_fk_film_category_film");

            builder.Property(e => e.FilmId).HasColumnName("film_id");

            builder.Property(e => e.CategoryId).HasColumnName("category_id");

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.FilmCategory)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_category_category");

            builder.HasOne(d => d.Film)
                .WithMany(p => p.FilmCategory)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_category_film");
        }
    }
}