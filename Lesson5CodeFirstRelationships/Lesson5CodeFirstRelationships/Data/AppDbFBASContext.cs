using Lesson5CodeFirstRelationships.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson5CodeFirstRelationships.Data;

public class AppDbFBASContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=STHQ0118-01;Initial Catalog=AppDbFBAS;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Kamil");
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
        modelBuilder.Entity<Student>().Property(s => s.Surname).HasDefaultValue("kamil");
        modelBuilder.Entity<Student>().Property(s => s.Surname).HasColumnType("varchar(max)");
        modelBuilder.Entity<Student>().Property(s => s.Surname).HasColumnName("Soyadi");

        modelBuilder.Entity<User>()
                    .HasOne(u => u.Number)
                    .WithOne(pn => pn.User)
                    .HasForeignKey<PhoneNumber>(pn => pn.Id)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
                    .HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.AuthorId, ab.BookId });

        modelBuilder.Entity<AuthorBook>()
                    .HasOne(ab => ab.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(ab => ab.AuthorId);

        modelBuilder.Entity<AuthorBook>()
                    .HasOne(ab => ab.Book)
                    .WithMany(b => b.Authors)
                    .HasForeignKey(ab => ab.BookId);

    }
}
