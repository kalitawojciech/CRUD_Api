using crud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.Core.Interfaces
{
    public interface IProductRepository
    {
        ProductEntity GetProduct(int id);
        IEnumerable<ProductEntity> GetProducts();
    }
}
