using System;
using System.Collections;
using System.Linq;
using Microsoft. EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using entity_frawework_core_1.Model;

namespace entity_frawework_core_1.Dados  
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        void IEntityTypeConfiguration<Film>.Configure(EntityTypeBuilder<Film> builder)
        {            
                builder.ToTable("film");

                builder.HasIndex(e => e.LanguageId)
                    .HasName("idx_fk_language_id");

                builder.HasIndex(e => e.OriginalLanguageId)
                    .HasName("idx_fk_original_language_id");

                builder.Property(e => e.FilmId).HasColumnName("film_id");

                builder.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                builder.Property(e => e.LanguageId).HasColumnName("language_id");

                builder.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                builder.Property(e => e.Length).HasColumnName("length");

                builder.Property(e => e.OriginalLanguageId).HasColumnName("original_language_id");

                builder.Property(e => e.parentalRating)
                    .HasColumnName("rating")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('G')");

                builder.Property(e => e.ReleaseYear)
                    .HasColumnName("release_year")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                builder.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                builder.HasOne(d => d.Language)
                    .WithMany(p => p.FilmLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_language");

                builder.HasOne(d => d.OriginalLanguage)
                    .WithMany(p => p.FilmOriginalLanguage)
                    .HasForeignKey(d => d.OriginalLanguageId)
                    .HasConstraintName("fk_film_language_original");
        }
    }
}

// Example of the declariton shadow property
// builder.Property<DateTime>("last_update")
//        .HasColumnType("datetime")
//        .DefaultValue("getdate()");