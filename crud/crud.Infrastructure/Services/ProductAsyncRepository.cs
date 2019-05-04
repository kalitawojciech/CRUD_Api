﻿using crud.Core.Entities;
using crud.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.Infrastructure.Services
{
    public class ProductAsyncRepository : IProductAsyncRepository
    {
        private ProductContext _context;

        public ProductAsyncRepository(ProductContext context)
        {
            _context = context;
        }
        public void AddProduct(ProductEntity productToAdd)
        {
            if (productToAdd == null)
            {
                throw new ArgumentNullException(nameof(productToAdd));
            }

            _context.Add(productToAdd);
        }

        public async Task<ProductEntity> GetProductAsync(int id)
        {
            return await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<ProductEntity>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
