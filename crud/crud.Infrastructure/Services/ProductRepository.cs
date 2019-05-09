using crud.Core.Entities;
using crud.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud.Infrastructure
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductEntity productToAdd)
        {
            if(productToAdd == null)
            {
                throw new ArgumentNullException(nameof(productToAdd));
            }

            _context.Add(productToAdd);
        }

        public ProductEntity GetProduct(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
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

        public void DeleteProduct(ProductEntity product)
        {
            _context.Products.Remove(product);
        }
    }
}
