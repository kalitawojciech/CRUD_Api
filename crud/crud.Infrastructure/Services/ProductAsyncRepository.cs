using crud.Core.Entities;
using crud.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crud.Infrastructure.Services
{
    class ProductAsyncRepository : IProductAsyncRepository
    {
        public void AddProduct(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> GetProductAsync(int id)
        {
            throw new NotImplementedException();
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
