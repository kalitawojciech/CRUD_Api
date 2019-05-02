using crud.Core.Entities;
using crud.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.Infrastructure.Services
{
    class ProductAsyncRepository : IProductAsyncRepository
    {
        private ProductContext _context;

        public ProductAsyncRepository(ProductContext context)
        {
            _context = context;
        }
        public void AddProduct(ProductEntity product)
        {
            throw new NotImplementedException();
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
