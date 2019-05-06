using AutoMapper;
using crud.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Api.Controllers
{
    [Route("api/product/async")]
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
    }
}
