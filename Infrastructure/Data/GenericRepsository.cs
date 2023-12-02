using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class GenericRepsository<TEnity> : IGenericRepository<TEnity> where TEnity : BaseEntity
	{
        private readonly StoreContext _context;

        public GenericRepsository(StoreContext context)
		{
            _context = context;
		}

        public async Task<TEnity?> GetItemAsync(ISpecification<TEnity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEnity>> GetItemsAsync(ISpecification<TEnity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEnity> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public Task DeleteItemAsync(Expression<Func<TEnity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task SaveItemAsync(TEnity entity)
        {
            throw new NotImplementedException();
        }

        private IQueryable<TEnity> ApplySpecification(ISpecification<TEnity>spec)
        {
            return SpecificationEvaluator<TEnity>.GetQuery(_context.Set<TEnity>().AsQueryable(), spec);
        }

        public async Task<IReadOnlyList<TEnity>> GetItemsAsync()
        {
            return await _context.Set<TEnity>().ToListAsync();
        }
    }
}

