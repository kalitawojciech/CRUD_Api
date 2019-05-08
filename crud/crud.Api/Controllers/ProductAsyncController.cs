using AutoMapper;
using crud.Core.Entities;
using crud.Core.Interfaces;
using crud.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Api.Controllers
{
    [Route("api/productasync")]
    [ApiController]
    public class ProductAsyncController : ControllerBase
    {
        private IProductAsyncRepository _productRepository;
        private IMapper _mapper;

        public ProductAsyncController(IProductAsyncRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsEntities = await _productRepository.GetProductsAsync();
            return Ok(productsEntities);
        }

        [HttpGet]
        [Route("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var productEntity = await _productRepository.GetProductAsync(productId);
            if(productEntity == null)
            {
                return NotFound();
            }
            return Ok(productEntity);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel productModel)
        {
            var productEntity = Mapper.Map<ProductEntity>(productModel);
            _productRepository.AddProduct(productEntity);
            await _productRepository.SaveChangesAsync();
            await _productRepository.GetProductAsync(productEntity.ProductId);

            return CreatedAtRoute("GetProduct", new { productId = productEntity.ProductId }, productEntity);

        }
    }
}
