﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Repositories.Base.Write
{
    public interface IWriteRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> ModifyAsync(TEntity entity, IEnumerable<string> modifiedFields);
        Task<TEntity> RemoveAsync(TKey key);
    }
}
