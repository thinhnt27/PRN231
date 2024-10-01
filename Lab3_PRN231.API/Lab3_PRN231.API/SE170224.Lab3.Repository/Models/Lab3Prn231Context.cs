using Lab3_PRN231.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3_PRN231.Repository.Models;

public partial class Lab3Prn231Context : DbContext
{
    public Lab3Prn231Context()
    {
    }

    public Lab3Prn231Context(DbContextOptions<Lab3Prn231Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_pkey");

            entity.ToTable("account");

            entity.Property(e => e.Id).HasColumnName("accountid");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("categoryid");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("productid");
            entity.Property(e => e.CategoryId).HasColumnName("categoryid");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("productname");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(18, 2)
                .HasColumnName("unitprice");
            entity.Property(e => e.UnitsInStock).HasColumnName("unitsinstock");

            //entity.HasOne(d => d.Category).WithMany(p => p.Products)
            //    .HasForeignKey(d => d.CategoryId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("fk_product_category");
        });

        modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = 1, Name = "Beverages" },
                new Category { Id = 2, Name = "Condiments" },
                new Category { Id = 3, Name = "Confections" },
                new Category { Id = 4, Name = "Dairy Products" },
                new Category { Id = 5, Name = "Grains/Cereals" },
                new Category { Id = 6, Name = "Meat/Poultry" },
                new Category { Id = 7, Name = "Produce" },
                new Category { Id = 8, Name = "Seafood" }
            );

        modelBuilder.Entity<Product>()
            .HasData(
                new Product { Id = 1, Name = "Chai", CategoryId = 1, UnitPrice = 18.00m, UnitsInStock = 39 },
                new Product { Id = 2, Name = "Chang", CategoryId = 1, UnitPrice = 19.00m, UnitsInStock = 17 },
                new Product { Id = 3, Name = "Aniseed Syrup", CategoryId = 2, UnitPrice = 10.00m, UnitsInStock = 13 },
                new Product { Id = 4, Name = "Chef Anton's Cajun Seasoning", CategoryId = 2, UnitPrice = 22.00m, UnitsInStock = 53 },
                new Product { Id = 5, Name = "Chef Anton's Gumbo Mix", CategoryId = 2, UnitPrice = 21.35m, UnitsInStock = 0 },
                new Product { Id = 6, Name = "Grandma's Boysenberry Spread", CategoryId = 2, UnitPrice = 25.00m, UnitsInStock = 120 },
                new Product { Id = 7, Name = "Uncle Bob's Organic Dried Pears", CategoryId = 7, UnitPrice = 30.00m, UnitsInStock = 15 },
                new Product { Id = 8, Name = "Northwoods Cranberry Sauce", CategoryId = 2, UnitPrice = 40.00m, UnitsInStock = 6 },
                new Product { Id = 9, Name = "Mishi Kobe Niku", CategoryId = 6, UnitPrice = 97.00m, UnitsInStock = 29 },
                new Product { Id = 10, Name = "Ikura", CategoryId = 8, UnitPrice = 31.00m, UnitsInStock = 31 },
                new Product { Id = 11, Name = "Queso Cabrales", CategoryId = 4, UnitPrice = 21.00m, UnitsInStock = 22 },
                new Product { Id = 12, Name = "Queso Manchego La Pastora", CategoryId = 4, UnitPrice = 38.00m, UnitsInStock = 86 },
                new Product { Id = 13, Name = "Konbu", CategoryId = 8, UnitPrice = 6.00m, UnitsInStock = 24 },
                new Product { Id = 14, Name = "Tofu", CategoryId = 7, UnitPrice = 23.25m, UnitsInStock = 35 },
                new Product { Id = 15, Name = "Genen Shouyu", CategoryId = 2, UnitPrice = 15.50m, UnitsInStock = 39 },
                new Product { Id = 16, Name = "Pavlova", CategoryId = 3, UnitPrice = 17.45m, UnitsInStock = 29 },
                new Product { Id = 17, Name = "Alice Mutton", CategoryId = 6, UnitPrice = 39.00m, UnitsInStock = 0 },
                new Product { Id = 18, Name = "Carnarvon Tigers", CategoryId = 8, UnitPrice = 62.50m, UnitsInStock = 2 }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
