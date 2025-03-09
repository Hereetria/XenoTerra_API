using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Repositories.Abstract
{
    public interface IWriteRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> ModifyAsync(TEntity entity);
        Task<bool> RemoveAsync(TKey key);
    }
}
