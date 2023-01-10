using Lab3.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Lab3.DataAccessLayer.Repositories
{
	public class BookRepository : IRepository<Book>
	{
		private readonly BookContext _context;
		private readonly DbSet<Book> _dbSet;
		private IMemoryCache _memory;
		private int _rowsNumber;

		public BookRepository(BookContext context, IMemoryCache memory)
		{
			_context = context;
			_dbSet = _context.Set<Book>();
			_memory = memory;
			_rowsNumber = 20;
		}

		public void Add(Book model)
		{
			
		}

		public void AddCache(string cacheKey)
		{
			
		}

		public void Delete(Book model)
		{
			
		}

		public Task<List<Book>> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<Book> GetAll(string cacheKey)
		{
			List<Book>? list = null;
			if (!_memory.TryGetValue(cacheKey, out list))
			{
				list = _dbSet.Take(_rowsNumber).Include(book => book.Genre).Include(book => book.EditionHouse).ToList();

				if (list != null)
				{
					_memory.Set(cacheKey, list,
					new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10080)));
				}
			}

			return list;
		}

		public Task Save()
		{
			throw new NotImplementedException();
		}

		public void Update(Book model)
		{
			throw new NotImplementedException();
		}
	}
}
