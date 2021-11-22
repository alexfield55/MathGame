using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MathGameContext _dbContext;

        public GenericRepository(MathGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        // by using read only app db context you can have access to only querying capabilities of db context
        // unit of work actually writes (commits) to the physical tables (not internal obj)
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null)
        {
            if (includes == null)
            {
                if (asNoTracking)
                {
                    return _dbContext.Set<T>()
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefault();
                }
                else
                {
                    return _dbContext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefault();
                }
            }
            else
            {
                IQueryable<T> queryable = _dbContext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (asNoTracking)
                {
                    return queryable
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefault();
                }
                else
                {
                    return queryable
                        .Where(predicate)
                        .FirstOrDefault();
                }
            }
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null)
        {
            if (includes == null)
            {
                if (asNoTracking)
                {
                    return await _dbContext.Set<T>()
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbContext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
            }
            else
            {
                IQueryable<T> queryable = _dbContext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (asNoTracking)
                {
                    return await queryable
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
                else
                {
                    return await queryable
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
            }
        }

        // the virtual keyword is used to mod a method, prop, indexer 
        // allows for it to be overridden in a derived class
        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        /// <summary>
        /// Repository Function to return a guid like in the case of the ASP Identity table
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Object Type T found by Guid </returns>
        public virtual T GetById(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> List()
        {
            return _dbContext.Set<T>().ToList().AsEnumerable();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, string includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbContext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            // has includes
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }

            if (predicate == null)
            {
                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    return queryable.OrderBy(orderBy).ToList().AsEnumerable();
                }
            }
            else
            {
                if (orderBy == null)
                {
                    return queryable.Where(predicate).ToList().AsEnumerable();
                }
                else
                {
                    return queryable.Where(predicate).OrderBy(orderBy).ToList().AsEnumerable();
                }

            }
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, string includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbContext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            // has includes
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }

            if (predicate == null)
            {
                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    return await queryable.OrderBy(orderBy).ToListAsync();
                }
            }
            else
            {
                if (orderBy == null)
                {
                    return await queryable.Where(predicate).ToListAsync();
                }
                else
                {
                    return await queryable.Where(predicate).OrderBy(orderBy).ToListAsync();
                }

            }
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
