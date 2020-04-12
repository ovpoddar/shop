﻿using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;

namespace Shop
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductWholeSale> ProductWholeSales { get; set; }
        public DbSet<WholesaleSize> WholesaleSize { get; set; }
        public DbSet<Csv> Csvs { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BalanceDataConfiguration());
        }
    }
}
