using System;
using Microsoft.EntityFrameworkCore;
using CobraCoding.Data;

namespace CobraCoding.Data;

public partial class CobraCodingContext : DbContext
{
    public CobraCodingContext() { }

    public CobraCodingContext(DbContextOptions<CobraCodingContext> options)
    : base(options) { }

    public virtual DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Make)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.Doors).HasColumnName("doors");
            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
