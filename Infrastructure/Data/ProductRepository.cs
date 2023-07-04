using System;
using System.Collections.Generic;
using Core.Interfaces;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Specifications.Products;
using SharedKernel.Enums;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductRepository(IGenericRepository<Product>repository)
        {
            _repository = repository;
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            return await _repository.GetItemAsync(spec);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(specParams);
            return await _repository.GetItemsAsync(spec);
        }
    }

}