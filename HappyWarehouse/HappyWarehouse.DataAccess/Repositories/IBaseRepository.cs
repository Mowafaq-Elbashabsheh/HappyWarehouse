using HappyWarehouse.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        IQueryable<T> GetAllInclude(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null, bool enableTracking = false);
        Task<bool> CheckUnique(Expression<Func<T, bool>> filter);
    }
}
