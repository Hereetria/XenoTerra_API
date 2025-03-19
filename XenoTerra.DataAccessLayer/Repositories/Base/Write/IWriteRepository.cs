using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Write
{
    public interface IWriteRepository<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        AppDbContext GetDbContext();
        Task<TDtoResult> InsertAsync(TEntity entity);
        Task<TDtoResult> ModifyAsync(TEntity entity);
        Task<bool> RemoveAsync(TKey key);
    }
}
