using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Entities;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthorEntity> Authors { get; set; }

    public virtual DbSet<BookEntity> Books { get; set; }

    public virtual DbSet<BookScoreEntity> BookScores { get; set; }

    public virtual DbSet<GenreEntity> Genres { get; set; }

    public virtual DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Library");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC0748535B1F");

            entity.Property(e => e.Country).HasMaxLength(25);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.RealName).HasMaxLength(50);
            entity.Property(e => e.WritingLanguage).HasMaxLength(25);
        });

        modelBuilder.Entity<BookEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC077F0A38B7");

            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__AuthorId__3E52440B");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__GenreId__3F466844");
        });

        modelBuilder.Entity<BookScoreEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookScor__3214EC07C67E25CA");

            entity.HasOne(d => d.Book).WithMany(p => p.BookScores)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookScore__BookI__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.BookScores)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookScore__UserI__4222D4EF");
        });

        modelBuilder.Entity<GenreEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC07F87D7D46");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07280248ED");

            entity.HasIndex(e => e.Login, "UQ__Users__5E55825B89818075").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Login).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
