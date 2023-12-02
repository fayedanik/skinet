
using System;
using Core.Entities;
using System.Collections.Generic;
using SharedKernel.Enums;
using Core.Specifications.Products;

namespace Core.Interfaces 
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<(IReadOnlyList<Product> data,int totalCount)> GetProductsAsync(ProductSpecParams specParams);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}



