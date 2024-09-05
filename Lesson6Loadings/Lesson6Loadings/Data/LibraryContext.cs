using System;
using System.Collections.Generic;
using Lesson6Loadings.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson6Loadings.Data;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<SCard> SCards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=STHQ0118-01;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False").UseLazyLoadingProxies().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(25);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("OldBook"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasMaxLength(50);
            entity.Property(e => e.IdAuthor).HasColumnName("Id_Author");
            entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            entity.Property(e => e.IdPress).HasColumnName("Id_Press");
            entity.Property(e => e.IdThemes).HasColumnName("Id_Themes");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("FK_Books_Author");

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Category");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SCard>(entity =>
        {
            entity.ToTable("S_Cards", tb =>
                {
                    tb.HasTrigger("CheckQuantity");
                    tb.HasTrigger("CheckStudent");
                    tb.HasTrigger("ReturnBook");
                });

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
            entity.Property(e => e.IdLib).HasColumnName("Id_Lib");
            entity.Property(e => e.IdStudent).HasColumnName("Id_Student");

            entity.HasOne(d => d.Book).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Book");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
