using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
	public interface ISpecification<T> where T : BaseEntity
	{
		Expression<Func<T, bool>> Criteria { get; }
		List<Expression<Func<T, object>>> Includes { get; }
		Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
		public int Skip { get; }
		public int Take { get; }
		public bool IsEnabledPagination { get; }
	}
}

