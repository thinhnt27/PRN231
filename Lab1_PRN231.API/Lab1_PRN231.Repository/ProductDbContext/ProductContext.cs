using Lab1_PRN231.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab1_PRN231.Repository.ProductDbContext;

public class ProductContext : DbContext
{
    public ProductContext()
    {

    }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Beverages" },
            new Category { CategoryId = 2, CategoryName = "Condiments" },
            new Category { CategoryId = 3, CategoryName = "Confections" },
            new Category { CategoryId = 4, CategoryName = "Dairy Products" },
            new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
            new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
            new Category { CategoryId = 7, CategoryName = "Produce" },
            new Category { CategoryId = 8, CategoryName = "Seafood" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Chai", CategoryId = 1, UnitPrice = 18.00m },
            new Product { ProductId = 2, ProductName = "Chang", CategoryId = 1, UnitPrice = 19.00m },
            new Product { ProductId = 3, ProductName = "Aniseed Syrup", CategoryId = 2, UnitPrice = 10.00m },
            new Product { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning", CategoryId = 2, UnitPrice = 22.00m },
            new Product { ProductId = 5, ProductName = "Chef Anton's Gumbo Mix", CategoryId = 2, UnitPrice = 21.35m },
            new Product { ProductId = 6, ProductName = "Grandma's Boysenberry Spread", CategoryId = 2, UnitPrice = 25.00m },
            new Product { ProductId = 7, ProductName = "Uncle Bob's Organic Dried Pears", CategoryId = 7, UnitPrice = 30.00m },
            new Product { ProductId = 8, ProductName = "Northwoods Cranberry Sauce", CategoryId = 2, UnitPrice = 40.00m },
            new Product { ProductId = 9, ProductName = "Mishi Kobe Niku", CategoryId = 6, UnitPrice = 97.00m },
            new Product { ProductId = 10, ProductName = "Ikura", CategoryId = 8, UnitPrice = 31.00m },
            new Product { ProductId = 11, ProductName = "Queso Cabrales", CategoryId = 4, UnitPrice = 21.00m },
            new Product { ProductId = 12, ProductName = "Queso Manchego La Pastora", CategoryId = 4, UnitPrice = 38.00m },
            new Product { ProductId = 13, ProductName = "Konbu", CategoryId = 8, UnitPrice = 6.00m },
            new Product { ProductId = 14, ProductName = "Tofu", CategoryId = 7, UnitPrice = 23.25m },
            new Product { ProductId = 15, ProductName = "Genen Shouyu", CategoryId = 2, UnitPrice = 15.50m },
            new Product { ProductId = 16, ProductName = "Pavlova", CategoryId = 3, UnitPrice = 17.45m },
            new Product { ProductId = 17, ProductName = "Alice Mutton", CategoryId = 6, UnitPrice = 39.00m },
            new Product { ProductId = 18, ProductName = "Carnarvon Tigers", CategoryId = 8, UnitPrice = 62.50m },
            new Product { ProductId = 19, ProductName = "Teatime Chocolate Biscuits", CategoryId = 3, UnitPrice = 9.20m },
            new Product { ProductId = 20, ProductName = "Sir Rodney's Marmalade", CategoryId = 3, UnitPrice = 81.00m },
            new Product { ProductId = 21, ProductName = "Sir Rodney's Scones", CategoryId = 3, UnitPrice = 10.00m }
        );
    }
}

