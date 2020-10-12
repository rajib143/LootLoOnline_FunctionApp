using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LootLoOnline_FunctionApp.Interface
{

    public interface IDataRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAll();
        Task<List<T>> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderExpression = null);
        Task<List<T>> GetAllByFilter(int? page, int? pageSize, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort);
        Task<List<T>> GetOffersByFilter(int? page, int? pageSize, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort);
        Task<int> Add(T item);
        Task<bool> BulkAdd(List<T> item);
        Task<T> Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<int> Update(T item);
        Task<bool> Delete(T Item);
        Task<bool> BulkDelete(List<T> item);
    }
}
