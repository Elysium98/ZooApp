using Bissoft.Interview.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bissoft.Interview.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AnimalEntity> Animals { get; set; }
        public DbSet<ZooKeeperEntity> ZooKeepers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalEntity>(entity =>
            {
                entity.ToTable("Animal");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateOfBirth)
                   .HasColumnName("DateOfBirth")
                   .HasColumnType("date");

                entity.Property(e => e.AnimalType)
                   .HasConversion(value => value.ToString(),
                    value => (AType)Enum.Parse(typeof(AType), value))
                  .HasColumnName("Type")
                  .HasColumnType("INTEGER");
            });

            modelBuilder.Entity<ZooKeeperEntity>(entity =>
            {
                entity.ToTable("ZooKeeper");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                   .HasColumnName("Name")
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
            });

            modelBuilder.Entity<AnimalEntity>()
              .HasOne(s => s.ZooKeeper)
              .WithMany(g => g.Animals)
              .HasForeignKey(s => s.ZooKeeperId);
        }
    }
}
