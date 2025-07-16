using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BusinessObjects.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public MyDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfiguration configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
            }
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

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

            modelBuilder.Entity<Role>().HasData(
               new Role { RoleId = 1, RoleName = "Admin" },
               new Role { RoleId = 2, RoleName = "Customer" },
               new Role { RoleId = 3, RoleName = "Manager" }


           );

            modelBuilder.Entity<Product>().HasData(
    new Product
    {
        ProductId = 1,
        ProductName = "Coca-Cola",
        CategoryId = 1, // Beverages
        UnitPrice = 15000,
        UnitsInStock = 100
    },
    new Product
    {
        ProductId = 2,
        ProductName = "Pepsi",
        CategoryId = 1, // Beverages
        UnitPrice = 14000,
        UnitsInStock = 120
    },
    new Product
    {
        ProductId = 3,
        ProductName = "Chili Sauce",
        CategoryId = 2, // Condiments
        UnitPrice = 20000,
        UnitsInStock = 50
    },
    new Product
    {
        ProductId = 4,
        ProductName = "Chocolate Bar",
        CategoryId = 3, // Confections
        UnitPrice = 18000,
        UnitsInStock = 75
    },
    new Product
    {
        ProductId = 5,
        ProductName = "Milk",
        CategoryId = 4, // Dairy Products
        UnitPrice = 22000,
        UnitsInStock = 60
    },
    new Product
    {
        ProductId = 6,
        ProductName = "Oats",
        CategoryId = 5, // Grains/Cereals
        UnitPrice = 30000,
        UnitsInStock = 90
    },
    new Product
    {
        ProductId = 7,
        ProductName = "Chicken Breast",
        CategoryId = 6, // Meat/Poultry
        UnitPrice = 55000,
        UnitsInStock = 40
    },
    new Product
    {
        ProductId = 8,
        ProductName = "Carrots",
        CategoryId = 7, // Produce
        UnitPrice = 12000,
        UnitsInStock = 80
    },
    new Product
    {
        ProductId = 9,
        ProductName = "Salmon",
        CategoryId = 8, // Seafood
        UnitPrice = 95000,
        UnitsInStock = 30
    }
);

        }
    }
}

