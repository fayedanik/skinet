using System;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using API.Errors;
using System.Net;
using API.Queries;
using API.Helpers;
using MediatR;

namespace API.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;
        public readonly IMediator _mediator;
        public ProductsController(
            IProductRepository repo,
            IMapper mapper,
            ILogger<ProductsController> logger,
            IMediator mediator)
        {
            _productRepository = repo;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductQuery query)
        {
            _logger.LogInformation("Inside GetProducts Controller");
            var productSpecParam = ProductQuery.CreateProductSpecParam(query);
            var (data,totalCount) = await _productRepository.GetProductsAsync(productSpecParam);
            var dtoData = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(data);
            var result = new Pagination<ProductToReturnDto>(dtoData, totalCount);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto?>> GetProduct(int id)
        {
            var product  = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound(new ApiResponse((int)HttpStatusCode.NotFound));
            var result = _mapper.Map<Product, ProductToReturnDto>(product);
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<ActionResult<Pagination<ProductTypesToReturnDto>>> GetProductTypes()
        {
            var productTypes = await _productRepository.GetProductTypesAsync();
            var dtoData = _mapper.Map<IReadOnlyList<ProductType>, IReadOnlyList<ProductTypesToReturnDto>>(productTypes);
            var result = new Pagination<ProductTypesToReturnDto>(dtoData, productTypes.Count);
            return result;
        }

        // [HttpGet]
        // public async Task<ActionResult<Pagination<ProductTypesToReturnDto>>> GetProductBrands()
        // {

        // }
    }
}

