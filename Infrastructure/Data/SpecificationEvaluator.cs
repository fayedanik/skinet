using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications
{
	public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity>inputQuery,ISpecification<TEntity>spec)
		{
			var query = inputQuery;
			if( spec.Criteria != null )
			{
				query = query.Where(spec.Criteria);
			}

			if( spec.OrderBy != null )
			{
				query = query.OrderBy(spec.OrderBy);
			}

			if( spec.OrderByDesc != null )
			{
				query = query.OrderByDescending(spec.OrderByDesc);
			}

			if( spec.IsEnabledPagination )
			{
				query = query.Skip(spec.Skip).Take(spec.Take);
			}
	
			query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

			return query;
		}
	}
}

