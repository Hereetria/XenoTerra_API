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
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.DataAccessLayer.Repositories.Base.Read
{
    public class ReadRepository<TEntity, TKey>(AppDbContext context) : IReadRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context), $"{nameof(context)} cannot be null.");

        public AppDbContext GetDbContext()
        {
            return _context;
        }

        public IQueryable<TEntity> GetRawQueryable()
        {
            return _context.Set<TEntity>();
        }


        public IQueryable<TEntity> GetAllQueryable(IQueryable<TEntity> query, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");

            var selector = SimpleDbProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_context, selectedFields);

            return ExecuteSafely(() => query.AsNoTracking().Select(selector));
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

            return ExecuteSafely(() => query.AsNoTracking()
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

            return ExecuteSafely(() => query.AsNoTracking()
                .Where(entity => keySet.Contains(EF.Property<TKey>(entity, primaryKey.Properties[0].Name)))
                .Select(selector));
        }

        private static TResult ExecuteSafely<TResult>(Func<TResult> query)
        {
            try
            {
                return query();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InvalidOperationException("A concurrency conflict occurred during data access.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An invalid operation was attempted during query execution.", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("An invalid argument was provided to the query.", ex);
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("The query has timed out while accessing the database.", ex);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("A SQL error occurred while executing the query.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while executing the query.", ex);
            }
        }
    }
}