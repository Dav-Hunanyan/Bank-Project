using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankDAL.Models;

public partial class BankEmulatorContext : DbContext
{
    public BankEmulatorContext()
    {
    }

    public BankEmulatorContext(DbContextOptions<BankEmulatorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<UserAccessData> UserAccessData { get; set; }

    public virtual DbSet<UserData> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BankEmulator;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankAcco__3214EC07B9537068");

            entity.ToTable("BankAccount");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CurrentAmount).HasColumnType("money");

            entity.HasOne(d => d.User).WithMany(p => p.BankAccounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BankAccou__UserI__2C3393D0");
        });

        modelBuilder.Entity<UserAccessData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAcce__3214EC07FFB1DB0E");

            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.UserAccessData)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAcces__UserI__286302EC");
        });

        modelBuilder.Entity<UserData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserData__3214EC07AE2856E0");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
