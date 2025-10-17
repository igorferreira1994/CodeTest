
using CodeTest.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CodeTest.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cnab> Cnabs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cnab>(entity =>
            {
                entity.ToTable("Cnabs");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Date).IsRequired().HasColumnType("date");
                entity.Property(e => e.Value).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.CPF).IsRequired().HasMaxLength(11);
                entity.Property(e => e.Card).IsRequired().HasMaxLength(12);
                entity.Property(e => e.Time).IsRequired().HasColumnType("time");
                entity.Property(e => e.StoreOwner).IsRequired().HasMaxLength(14);
                entity.Property(e => e.StoreName).IsRequired().HasMaxLength(19);
            });
        }
    }
}
