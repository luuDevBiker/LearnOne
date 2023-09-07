using LearnOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Diagnostics.CodeAnalysis;

namespace LearnOne.Data {
    public class ApplicationDbContext : DbContext {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }

        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasKey(c => c.Id);
            modelBuilder.Entity<City>().HasIndex(c => c.Id).IncludeProperties(entity => new { entity.Name });
            modelBuilder.Entity<City>().HasIndex(c => c.Name).IncludeProperties(entity => new { entity.Id });


            modelBuilder.Entity<District>().HasKey(entity => entity.Id);
            modelBuilder.Entity<District>().Property(entity => entity.Wards).HasColumnType("jsonb");
            modelBuilder.Entity<District>().HasIndex(c => c.Id).IncludeProperties(entity => new { entity.Name, entity.Wards });
            modelBuilder.Entity<District>().HasIndex(c => c.Name).IncludeProperties(entity => new { entity.Id, entity.Wards });
            modelBuilder.Entity<District>().HasOne(c => c.Cty).WithMany(c => c.Districts).HasForeignKey(c => c.CtyId);


        }
    }
}