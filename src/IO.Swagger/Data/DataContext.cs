using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IO.Swagger.Models;

namespace IO.Swagger.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Pet>().HasMany(b => b.Tags).WithOne(p => p.Pet)
                .HasForeignKey(p => p.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.PetId);

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
