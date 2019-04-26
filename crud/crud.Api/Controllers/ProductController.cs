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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var productEntities = _productRepository.GetProducts();
            var productModels = _mapper.Map<IEnumerable<ProductModel>>(productEntities);
            return Ok(productModels);
        }

        [HttpGet]
        [Route("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var productEntity = _productRepository.GetProduct(id);
            if(productEntity == null)
            {
                return NotFound();
            }
            var productModel = _mapper.Map<ProductModel>(productEntity);
            return Ok(productModel);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            _productRepository.AddProduct(productEntity);
            _productRepository.SaveChanges();

            //_productRepository.GetProduct(productEntity.ProductId);
            //return CreatedAtRoute("GetProduct", new { id = productEntity.ProductId }, productEntity);
            return Ok();
        }
    }
}
