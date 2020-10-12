using LootLoOnline_FunctionApp.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LootLoOnline_FunctionApp.Repository
{

    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly LootLoOnlineDbContext _lootLoOnlineDatabaseContext;
        //private IConfiguration configuration;
        //public IMemoryCache MemoryCache { get; }
        //public DataRepository(IConfiguration config, IMemoryCache memoryCache)
        //{
        //    configuration = config;
        //    MemoryCache = memoryCache;

        //    _lootLoOnlineDatabaseContext = new LootLoOnlineDbContext(configuration, memoryCache);
        //}

        public DataRepository(LootLoOnlineDbContext lootLoOnlineDbContext)
        {

            _lootLoOnlineDatabaseContext = lootLoOnlineDbContext;
        }
        public async Task<IQueryable<T>> GetAll()
        {
            try
            {
                return _lootLoOnlineDatabaseContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderExpression = null)
        {
            var result = _lootLoOnlineDatabaseContext.Set<T>().AsQueryable();

            if (predicate != null)
                result = result.Where(predicate);

            if (orderExpression != null)
                result = orderExpression(result);


            return result.ToList();
        }
        public async Task<List<T>> GetAllByFilter(int? page, int? pageSize, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort)
        {
            var result = _lootLoOnlineDatabaseContext.Set<T>().AsQueryable();

            if (predicate != null)
                result = result.Where(predicate);

            if (sort != null)
                result = result.OrderByDescending(sort);

            if (page.HasValue && pageSize.HasValue)
                result = result.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return result.ToList();
        }
        public async Task<T> Get(Func<T, bool> where,
         params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                T item = null;
                IQueryable<T> dbQuery = _lootLoOnlineDatabaseContext.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause

                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<int> Add(T item)
        {
            try
            {
                _lootLoOnlineDatabaseContext.Set<T>().Add(item);
                return _lootLoOnlineDatabaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> BulkAdd(List<T> items)
        {
            try
            {

                _lootLoOnlineDatabaseContext.Set<T>().AddRange(items);
                _lootLoOnlineDatabaseContext.SaveChanges();

            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("Value cannot be null"))
                {

                    foreach (var T in items)
                    {
                        try
                        {
                            _lootLoOnlineDatabaseContext.Set<T>().Add(T);
                        }
                        catch (Exception)
                        {
                            _lootLoOnlineDatabaseContext.SaveChanges();
                        }
                    }
                    _lootLoOnlineDatabaseContext.SaveChanges();

                }
                else if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {

                    var se = ex.InnerException.InnerException as SqlException;
                    var code = se.Number;
                    if (se.Number == 2627)
                    {
                        foreach (var T in items)
                        {
                            try
                            {
                                this.Update(T);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }

            }
            finally
            {

            }

            return true;
        }
        public async Task<int> Update(T item)
        {
            try
            {
                _lootLoOnlineDatabaseContext.Set<T>().Attach(item);
                return _lootLoOnlineDatabaseContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(T item)
        {
            try
            {
                //using (var context = new LootLoOnlineDatabaseEntities())
                //{
                _lootLoOnlineDatabaseContext.Set<T>().Remove(item);
                _lootLoOnlineDatabaseContext.SaveChanges();
                //}
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> BulkDelete(List<T> items)
        {
            try
            {
                //using (var context = new LootLoOnlineDatabaseEntities())
                //{
                // context.Set<T>().SqlQuery("exec [Flipkart].[RemoveOldOfferProducts]");
                // _lootLoOnlineDatabaseContext.RemoveOldOfferProducts();
                //context.SaveChanges();
                //}

                //_lootLoOnlineDatabaseEntities.Set<T>().RemoveRange(items);
                //_lootLoOnlineDatabaseEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<T>> GetOffersByFilter(int? page, int? pageSize, System.Linq.Expressions.Expression<Func<T, bool>> predicate, System.Linq.Expressions.Expression<Func<T, object>> sort)
        {
            var result = _lootLoOnlineDatabaseContext.Set<T>().AsQueryable();

            if (predicate != null)
                result = result.Where(predicate);

            if (sort != null)
                result = result.OrderBy(sort);

            if (page.HasValue && pageSize.HasValue)
                result = result.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return result.ToList();
        }

    }
}
