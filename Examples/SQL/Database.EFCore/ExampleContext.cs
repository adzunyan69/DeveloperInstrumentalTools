using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<MoviesEntity> Movies { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<MoviesEntity>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(x => x.MoviesId);
                entity.Property(x => x.MoviesId).UseIdentityColumn();
                entity.Property(x => x.MoviesId).UseIdentityColumn();
            });
            modelBuilder.Entity<MoviesEntity>().HasData(new MoviesEntity { MoviesId = 1, Name = "First Title", Year = 1990 });
            modelBuilder.Entity<MoviesEntity>().HasData(new MoviesEntity { MoviesId = 2, Name = "Second Title", Year = 2000 });
            modelBuilder.Entity<MoviesEntity>().HasData(new MoviesEntity { MoviesId = 3, Name = "Third Title", Year = 2020 });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
