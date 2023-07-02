using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
	public interface ISpecification<T> where T : BaseEntity
	{
		Expression<Func<T, bool>> Criteria { get; }
		List<Expression<Func<T, object>>> Includes { get; }
	}
}

