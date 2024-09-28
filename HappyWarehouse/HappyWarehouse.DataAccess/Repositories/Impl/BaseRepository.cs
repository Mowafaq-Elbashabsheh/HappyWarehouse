using HappyWarehouse.Core.Common;
using HappyWarehouse.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.DataAccess.Repositories.Impl
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly WarehouseDBContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(WarehouseDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> CheckUnique(Expression<Func<T, bool>> filter)
        {
            var entity = await _dbSet.Where(filter).FirstOrDefaultAsync();
            if(entity == null)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteAsync(int id)
        {
            var entitiy = _dbSet.Where(x=>x.Id == id).First();
            var removedEntity = _dbSet.Remove(entitiy).Entity;
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAllInclude(Expression<Func<T,bool>> filter = null, List<Expression<Func<T,object>>> includes = null, bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if(includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if(filter != null)
            {
                query = query.Where(filter);
            }
            else
            {
                enableTracking = false;
            }

            return enableTracking ? query : query.AsNoTracking();
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbSet.Where(predicate).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
