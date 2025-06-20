using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Helpers.Abstract
{
    public interface IExistenceChecker<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        Task<bool> ExistsAsync(
            TDto dto,
            Expression<Func<TEntity, object>>? excludeIdExpression = null,
            params Expression<Func<TEntity, object>>[] matchExpressions);

    }
}
