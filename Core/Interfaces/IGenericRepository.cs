using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		Task<TEntity?> GetItemAsync(ISpecification<TEntity>specification);
		Task<IReadOnlyList<TEntity>> GetItemsAsync(ISpecification<TEntity> specification);
		Task SaveItemAsync(TEntity entity);
		Task DeleteItemAsync(Expression<Func<TEntity, bool>> expression);
	}
}

