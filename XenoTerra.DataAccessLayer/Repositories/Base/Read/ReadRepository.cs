using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.DataAccessLayer.Repositories.Base.Read
{
    public class ReadRepository<TEntity, TKey>(AppDbContext context) : IReadRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly AppDbContext _context = context;

        public IQueryable<TEntity> GetRawQueryable()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllQueryable(IQueryable<TEntity> query, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            return RepositoryExceptionHandler.ExecuteReadSafely(() => query.AsNoTracking().Select(selector));
        }

        public IQueryable<TEntity> GetByIdQueryable(IQueryable<TEntity> query, TKey key, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureValidKey(key);
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException($"Entity type '{typeof(TEntity).Name}' not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey is null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException($"Entity '{typeof(TEntity).Name}' must define a single primary key");

            return RepositoryExceptionHandler.ExecuteReadSafely(() => query.AsNoTracking()
                .Where(e => EF.Property<TKey>(e, primaryKey.Properties[0].Name)!.Equals(key))
                .Select(selector));
        }

        public IQueryable<TEntity> GetByIdsQueryable(IQueryable<TEntity> query, IEnumerable<TKey> keys, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureNotNullOrEmpty(keys, "Key list cannot be null.", "At least one key must in keys.");
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException($"Entity type '{typeof(TEntity).Name}' not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey is null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException($"Entity '{typeof(TEntity).Name}' must define a single primary key");

            var keySet = new HashSet<TKey>(keys);

            return RepositoryExceptionHandler.ExecuteReadSafely(() => query.AsNoTracking()
                .Where(entity => keySet.Contains(EF.Property<TKey>(entity, primaryKey.Properties[0].Name)))
                .Select(selector));
        }
    }
}