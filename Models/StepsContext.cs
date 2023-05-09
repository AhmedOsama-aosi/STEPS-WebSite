using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StepsWebApp.Models;

public partial class StepsContext : DbContext
{
    public StepsContext()
    {
    }

    public StepsContext(DbContextOptions<StepsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Consumption> Consumptions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<StationInfo> StationInfos { get; set; }

    public virtual DbSet<StationStatus> StationStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserConsumption> UserConsumption { get; set; }

    public virtual DbSet<SolarPanelsOutput> SolarPanelsOutput { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=Steps;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Information");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Btn)
                .HasMaxLength(50)
                .HasColumnName("BTN");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.PhotoLink)
                .HasMaxLength(50)
                .HasColumnName("photoLink");
        });

        modelBuilder.Entity<Consumption>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Consumption");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Consume).HasColumnName("consume");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .HasColumnName("time");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .HasColumnName("link");
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .HasColumnName("photo");
        });

        modelBuilder.Entity<StationInfo>(entity =>
        {
            entity.HasKey(e => e.SystemId);

            entity.ToTable("StationInfo");

            entity.Property(e => e.BatteryDate).HasColumnType("date");
            entity.Property(e => e.BatteryType).HasMaxLength(50);
            entity.Property(e => e.InstallationDate).HasColumnType("date");
            entity.Property(e => e.InstallationType).HasMaxLength(50);
            entity.Property(e => e.InverterType).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.SolarPanelType).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.StationInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_StationInfo_Users");
        });

        modelBuilder.Entity<StationStatus>(entity =>
        {
            entity.ToTable("StationStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CloudStatus).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.SolarAngel).HasMaxLength(50);
            entity.Property(e => e.SunPostion).HasMaxLength(50);
            entity.Property(e => e.WindDirection).HasMaxLength(50);

            entity.HasOne(d => d.System).WithMany(p => p.StationStatuses)
                .HasForeignKey(d => d.SystemId)
                .HasConstraintName("FK_StationStatus_StationInfo");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
