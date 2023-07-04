using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
	public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
	{
		public BaseSpecification()
		{

		}

		public BaseSpecification(Expression<Func<T,bool>>criteria)
		{
			Criteria = criteria;
        }


		public Expression<Func<T, bool>> Criteria { get; }

		public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

		public Expression<Func<T,object>> OrderBy { get; protected set; }

        public Expression<Func<T, object>> OrderByDesc { get; protected set; }

        public int Skip { get; protected set; }

        public int Take { get; protected set; }

        public bool IsEnabledPagination { get; protected set; }

        protected void AddInclude(Expression<Func<T,object>>include)
		{
			Includes.Add(include);
		}

		protected void AddOrderBy(Expression<Func<T,object>>expression)
		{
			OrderBy = expression;
		}

        protected void AddOrderByDesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }

		protected void ApplyPagination(int take,int skip)
		{
			Take = take;
			Skip = skip;
			IsEnabledPagination = true;
		}

	}
}

