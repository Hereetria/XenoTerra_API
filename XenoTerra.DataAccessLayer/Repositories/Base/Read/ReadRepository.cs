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
        where TKey : notnull
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public AppDbContext GetDbContext()
        {
            return _context;
        }

        public IQueryable<TEntity> GetAllQueryable(IEnumerable<string> selectedFields)
        {
            if (selectedFields is null || !selectedFields.Any())
                throw new ArgumentException("At least one field must be selected.", nameof(selectedFields));

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            return _dbSet.AsNoTracking()
                .Select(selector);

        }

        public IQueryable<TEntity> GetByIdQueryable(TKey key, IEnumerable<string> selectedFields)
        {
            if (key is null || (EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid)))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            if (selectedFields is null || !selectedFields.Any())
                throw new ArgumentException("At least one field must be selected.", nameof(selectedFields));

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey is null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            return _dbSet.AsNoTracking()
                .Where(e => EF.Property<TKey>(e, primaryKey.Properties[0].Name)!.Equals(key))
                .Select(selector);
        }

        public IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedFields)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            if (selectedFields is null || !selectedFields.Any())
                throw new ArgumentException("At least one field must be selected.", nameof(selectedFields));

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey is null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            var keySet = new HashSet<TKey>(keys);

            return _dbSet.AsNoTracking()
                .Where(entity => keySet.Contains(EF.Property<TKey>(entity, primaryKey.Properties[0].Name)))
                .Select(selector);
        }

    }
}