using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst_Bus.Models;

public partial class BusContext : DbContext
{
    public BusContext()
    {
    }

    public BusContext(DbContextOptions<BusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS; initial catalog=bus; integrated security=SSPI; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.BusName).HasName("PK__bus__283EB7063C50E609");

            entity.ToTable("bus");

            entity.Property(e => e.BusName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bus_name");
            entity.Property(e => e.Route)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("route");
            entity.Property(e => e.Timing)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("timing");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Mobile).HasName("PK__customer__A32E2E1D018088D3");

            entity.ToTable("customer");

            entity.Property(e => e.Mobile)
                .ValueGeneratedNever()
                .HasColumnName("mobile");
            entity.Property(e => e.BusName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bus_name");
            entity.Property(e => e.CName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("c_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
