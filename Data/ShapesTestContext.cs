using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shapesapp.Data
{
    public partial class ShapesTestContext : DbContext
    {
        public ShapesTestContext()
        {
        }

        public ShapesTestContext(DbContextOptions<ShapesTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Shape> Shapes { get; set; } = null!;
        public virtual DbSet<ShapeType> ShapeTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=slowsense.database.windows.net;Initial Catalog=ShapesTest;User ID=SlowSenseTest;Password=slow-test-55");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shape>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PositionX).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PositionY).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Text).HasMaxLength(50);

                entity.HasOne(d => d.FormsType)
                    .WithMany(p => p.Shapes)
                    .HasForeignKey(d => d.FormsTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shapes_ShapeTypes");
            });

            modelBuilder.Entity<ShapeType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
