﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Write
{
    public interface IWriteRepository<TEntity, TKey>
        where TEntity : class
    {
        AppDbContext GetDbContext();
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> ModifyAsync(TEntity entity);
        Task<bool> RemoveAsync(TKey key);
    }
}
