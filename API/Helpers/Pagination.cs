using System;
namespace API.Helpers
{
	public class Pagination<T> where T : class
	{
		public int Total { get; set; }

		public IReadOnlyList<T> Data { get; set; } = new List<T>();

		public Pagination(IReadOnlyList<T> data, int total)
		{
			Total = total;
			Data = data;
		}
	}
}

