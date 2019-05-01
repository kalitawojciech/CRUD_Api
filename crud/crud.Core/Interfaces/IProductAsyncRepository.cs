using crud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crud.Core.Interfaces
{
    public interface IProductAsyncRepository
    {
        Task<ProductEntity> GetProductAsync(int id);
        Task<IEnumerable<ProductEntity>> GetProductsAsync();
        void AddProduct(ProductEntity product);
        Task<bool> SaveChangesAsync();
    }
}
