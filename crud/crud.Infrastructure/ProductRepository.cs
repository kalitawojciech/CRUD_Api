using crud.Core.Entities;
using crud.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public ProductEntity GetProduct(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
