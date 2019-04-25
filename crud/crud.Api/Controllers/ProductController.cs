using AutoMapper;
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
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult GetProducts()
        {
            var productEntities = _productRepository.GetProducts();
            return Ok(productEntities);
        }

        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            var productEntity = _productRepository.GetProduct(id);
            var productModel = _mapper.Map<ProductModel>(productEntity);
            return Ok(productModel);
        }
    }
}
