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
    public class LookupRepository<T> : ILookupRepository<T> where T : BaseLookup
    {
        private readonly WarehouseDBContext _context;
        private readonly DbSet<T> _dbSet;

        public LookupRepository(WarehouseDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbSet.Where(predicate).FirstOrDefaultAsync();
            
            return entity;
        }
    }
}
