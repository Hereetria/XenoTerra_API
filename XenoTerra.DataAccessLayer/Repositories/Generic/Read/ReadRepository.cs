using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Read
{
    public class ReadRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> QueryAll()
        {
            return _context.Set<TEntity>()
                .AsNoTracking();
        }

        public IQueryable<TEntity> QueryById(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null.");

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            return _context.Set<TEntity>()
                .AsNoTracking()
                .Where(e => EF.Property<TKey>(e, primaryKey.Properties[0].Name)!.Equals(key));
        }

        public IQueryable<TEntity> QueryByIds(IEnumerable<TKey> keys)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            var keySet = new HashSet<TKey>(keys);

            return _context.Set<TEntity>()
                .AsNoTracking()
                .Where(entity => keySet.Contains(EF.Property<TKey>(entity, primaryKey.Properties[0].Name)));
        }

    }
}