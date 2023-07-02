﻿using System;
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

		protected void AddInclude(Expression<Func<T,object>>include)
		{
			Includes.Add(include);
		}

    }
}

