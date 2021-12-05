using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dal.Models
{
    public partial class WeatherForecatDBContext : DbContext
    {
        public WeatherForecatDBContext()
        {
        }

        public WeatherForecatDBContext(DbContextOptions<WeatherForecatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CitiesAndLetters> CitiesAndLetters { get; set; }
        public virtual DbSet<Letters> Letters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP\\YEHUDIT;Database=WeatherForecatDB;User ID=DESKTOP\\User; Password=YRyr2066;Initial Catalog=WeatherForecatDB; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KeyCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabelCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CitiesAndLetters>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.LettersId).HasColumnName("LettersID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CitiesAndLetters)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CitiesAnd__CityI__4CA06362");

                entity.HasOne(d => d.Letters)
                    .WithMany(p => p.CitiesAndLetters)
                    .HasForeignKey(d => d.LettersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CitiesAnd__Lette__4D94879B");
            });

            modelBuilder.Entity<Letters>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SearchLetters)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
