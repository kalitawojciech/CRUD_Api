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
    public class ProductAsyncRepository : IProductAsyncRepository, IDisposable
    {
        private ProductContext _context;

        public ProductAsyncRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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

        public async Task<IEnumerable<ProductEntity>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
