using Lab3.DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Lab3.DataAccessLayer.Repositories
{
    public interface IRepository<TModel> where TModel : Model
    {
        void Add(TModel model);
        void AddCache(string cacheKey);
        void Delete(TModel model);
        Task<List<TModel>> GetAll();
		//Task<List<TModel>> GetAll<TProperty>(string cacheKey);
		List<TModel> GetAll(string cacheKey);
        Task Save();
        void Update(TModel model);
    }
}