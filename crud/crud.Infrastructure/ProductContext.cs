using crud.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity()
                {
                    ProductId = 1,
                    ProductName = "Ball",
                    ProductDescription = "The best ball to play football",
                    ProductPrice = 29.9M
                },
                new ProductEntity()
                {
                    ProductId = 2,
                    ProductName = "T-shirt",
                    ProductDescription = "Blue T-shirt",
                    ProductPrice = 19.9M
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
