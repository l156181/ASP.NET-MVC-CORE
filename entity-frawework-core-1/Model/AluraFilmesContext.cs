using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using entity_frawework_core_1.Dados;
using System.Collections.Generic;

namespace entity_frawework_core_1.Model
{
    public partial class AluraFilmesContext : DbContext
    {
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmActor> FilmActor { get; set; }
        public virtual DbSet<FilmCategory> FilmCategory { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AluraFilmes;Trusted_Connection=True;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                       
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new FilmActorConfiguration());
            modelBuilder.ApplyConfiguration(new FilmCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            // modelBuilder.Entity<Actor>(entity =>
            // {
                

            //     entity.ToTable("actor");

            //     entity.HasIndex(e => e.LastName)
            //         .HasName("idx_actor_last_name");

            //     entity.Property(e => e.ActorId).HasColumnName("actor_id");

            //     entity.Property(e => e.FirstName)
            //         .IsRequired()
            //         .HasColumnName("first_name")
            //         .HasMaxLength(45)                    
            //         .IsUnicode(false);

            //     entity.Property(e => e.LastName)
            //         .IsRequired()
            //         .HasColumnName("last_name")
            //         .HasMaxLength(45)
            //         .IsUnicode(false);

            //     entity.Property(e => e.LastUpdate)
            //         .HasColumnName("last_update")
            //         .HasColumnType("datetime")
            //         .HasDefaultValueSql("(getdate())");
            //       });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.LastName)
                    .HasName("idx_last_name");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            // modelBuilder.Entity<Film>(entity =>
            // {
            //     entity.ToTable("film");

            //     entity.HasIndex(e => e.LanguageId)
            //         .HasName("idx_fk_language_id");

            //     entity.HasIndex(e => e.OriginalLanguageId)
            //         .HasName("idx_fk_original_language_id");

            //     entity.Property(e => e.FilmId).HasColumnName("film_id");

            //     entity.Property(e => e.Description)
            //         .HasColumnName("description")
            //         .HasColumnType("text");

            //     entity.Property(e => e.LanguageId).HasColumnName("language_id");

            //     entity.Property(e => e.LastUpdate)
            //         .HasColumnName("last_update")
            //         .HasColumnType("datetime")
            //         .HasDefaultValueSql("(getdate())");

            //     entity.Property(e => e.Length).HasColumnName("length");

            //     entity.Property(e => e.OriginalLanguageId).HasColumnName("original_language_id");

            //     entity.Property(e => e.Rating)
            //         .HasColumnName("rating")
            //         .HasMaxLength(10)
            //         .IsUnicode(false)
            //         .HasDefaultValueSql("('G')");

            //     entity.Property(e => e.ReleaseYear)
            //         .HasColumnName("release_year")
            //         .HasMaxLength(4)
            //         .IsUnicode(false);

            //     entity.Property(e => e.Title)
            //         .IsRequired()
            //         .HasColumnName("title")
            //         .HasMaxLength(255)
            //         .IsUnicode(false);

            //     entity.HasOne(d => d.Language)
            //         .WithMany(p => p.FilmLanguage)
            //         .HasForeignKey(d => d.LanguageId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("fk_film_language");

            //     entity.HasOne(d => d.OriginalLanguage)
            //         .WithMany(p => p.FilmOriginalLanguage)
            //         .HasForeignKey(d => d.OriginalLanguageId)
            //         .HasConstraintName("fk_film_language_original");
            // });

            // modelBuilder.Entity<FilmActor>(entity =>
            // {
            //     entity.HasKey(e => new { e.ActorId, e.FilmId })
            //         .ForSqlServerIsClustered(false);

            //     entity.ToTable("film_actor");

            //     entity.HasIndex(e => e.ActorId)
            //         .HasName("idx_fk_film_actor_actor");

            //     entity.HasIndex(e => e.FilmId)
            //         .HasName("idx_fk_film_actor_film");

            //     entity.Property(e => e.ActorId).HasColumnName("actor_id");

            //     entity.Property(e => e.FilmId).HasColumnName("film_id");

            //     entity.Property(e => e.LastUpdate)
            //         .HasColumnName("last_update")
            //         .HasColumnType("datetime")
            //         .HasDefaultValueSql("(getdate())");

            //     entity.HasOne(d => d.Actor)
            //         .WithMany(p => p.FilmActor)
            //         .HasForeignKey(d => d.ActorId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("fk_film_actor_actor");

            //     entity.HasOne(d => d.Film)
            //         .WithMany(p => p.FilmActor)
            //         .HasForeignKey(d => d.FilmId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("fk_film_actor_film");
            // });

            // modelBuilder.Entity<FilmCategory>(entity =>
            // {
            //     entity.HasKey(e => new { e.FilmId, e.CategoryId })
            //         .ForSqlServerIsClustered(false);

            //     entity.ToTable("film_category");

            //     entity.HasIndex(e => e.CategoryId)
            //         .HasName("idx_fk_film_category_category");

            //     entity.HasIndex(e => e.FilmId)
            //         .HasName("idx_fk_film_category_film");

            //     entity.Property(e => e.FilmId).HasColumnName("film_id");

            //     entity.Property(e => e.CategoryId).HasColumnName("category_id");

            //     entity.Property(e => e.LastUpdate)
            //         .HasColumnName("last_update")
            //         .HasColumnType("datetime")
            //         .HasDefaultValueSql("(getdate())");

            //     entity.HasOne(d => d.Category)
            //         .WithMany(p => p.FilmCategory)
            //         .HasForeignKey(d => d.CategoryId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("fk_film_category_category");

            //     entity.HasOne(d => d.Film)
            //         .WithMany(p => p.FilmCategory)
            //         .HasForeignKey(d => d.FilmId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("fk_film_category_film");
            // });

            // modelBuilder.Entity<Language>(entity =>
            // {
            //     entity.ToTable("language");

            //     entity.Property(e => e.LanguageId)
            //         .HasColumnName("language_id")
            //         .ValueGeneratedOnAdd();

            //     entity.Property(e => e.LastUpdate)
            //         .HasColumnName("last_update")
            //         .HasColumnType("datetime")
            //         .HasDefaultValueSql("(getdate())");

            //     entity.Property(e => e.Name)
            //         .IsRequired()
            //         .HasColumnName("name")
            //         .HasColumnType("char(20)");
            // });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });
        }
    }
}
