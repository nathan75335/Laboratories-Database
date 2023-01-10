using Lab3.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Lab3.DataAccessLayer.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : Models.Model
    {
        private readonly BookContext _context;
        private readonly DbSet<TModel> _dbSet;
        private IMemoryCache _memory; 
        private int _rowsNumber;

        public Repository(BookContext context, DbSet<TModel> dbSet, IMemoryCache memory)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
            _memory = memory;
            _rowsNumber = 20;
        }

        public void Add(TModel model)
        {
            _dbSet.Add(model);
        }

        public void Delete(TModel model)
        {
            _dbSet.Remove(model);
        }

        public void Update(TModel model)
        {
            _dbSet.Update(model);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

    //    public async Task<List<TModel>> GetAll<TProperty>(string cacheKey, params Expression<Func<TModel, TProperty>> [] navigations)
    //    {
    //        List<TModel>? list = null;

    //        if (!_memory.TryGetValue(cacheKey, out list))
    //        {

    //            foreach( var expression in navigations)
				//{
    //                _dbSet.Include(expression);
    //                Console.WriteLine(expression.GetType());
				//}

    //            list = await _dbSet.Take(_rowsNumber).ToListAsync();

    //            if (list != null)
    //            {
    //                _memory.Set(cacheKey, list,
    //                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10080)));
    //            }
    //        }

    //        return list;
    //    }

        public List<TModel> GetAll(string cacheKey)
		{
			List<TModel>? list = null;
            if (!_memory.TryGetValue(cacheKey, out list))
            {
				list = _dbSet.Take(_rowsNumber).ToList();

				if (list != null)
				{
					_memory.Set(cacheKey, list,
					new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10080)));
				}
			}

			return list;
		}


		public Task<List<TModel>> GetAll()
        {
            return _dbSet.Take(_rowsNumber).ToListAsync();
        }

        public void AddCache(string cacheKey)
        {
            var list = _dbSet.Take(_rowsNumber).ToListAsync();

            _memory.Set(cacheKey, list, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10080)
            });
        }
	}
}
