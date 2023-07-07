﻿using System;
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

namespace API.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _productRepository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductQuery query)
        {
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
    }
}

