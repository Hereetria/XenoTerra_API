using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Repositories.Base.Write
{
    public class WriteRepository<TEntity, TKey> : IWriteRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        protected virtual Task PreInsertAsync(TEntity entity) => Task.CompletedTask;
        protected virtual Task PreDeleteAsync(TEntity entity) => Task.CompletedTask;
        protected virtual Task PreUpdateAsync(TEntity entity, IEnumerable<string> modifiedFields) => Task.CompletedTask;


        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            ArgumentGuard.EnsureNotNull(entity);

            return await ExecuteWithTransactionAsync(async () =>
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }, "inserting");
        }

        public async Task<TEntity> RemoveAsync(TKey key)
        {
            ArgumentGuard.EnsureNotNullOrEmpty(key);
            var entity = await _dbSet.FindAsync(key)
                         ?? throw new KeyNotFoundException($"Entity with key '{key}' not found.");

            return await ExecuteWithTransactionAsync(async () =>
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }, "deleting");
        }

        public async Task<TEntity> ModifyAsync(TEntity entity, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(entity);

            return await ExecuteWithTransactionAsync(async () =>
            {
                _dbSet.Attach(entity);
                var entry = _context.Entry(entity);

                var keyProps = entry.Metadata.FindPrimaryKey()?.Properties;
                var keyNames = keyProps?.Select(p => p.Name).ToHashSet(StringComparer.OrdinalIgnoreCase) ?? [];

                foreach (var field in modifiedFields)
                {
                    if (keyNames.Contains(field))
                        continue;

                    var property = entry.Metadata.GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                    if (property is not null)
                    {
                        entry.Property(property.Name).IsModified = true;
                    }
                }

                await _context.SaveChangesAsync();
                return entity;
            }, "updating");
        }

        private async Task<TEntity> ExecuteWithTransactionAsync(Func<Task<TEntity>> operation, string operationName)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            return await RepositoryExceptionHandler.ExecuteWriteSafelyAsync(async () =>
            {
                var result = await operation();
                await transaction.CommitAsync();
                return result;
            }, async () =>
            {
                await transaction.RollbackAsync();
            }, operationName);
        }
    }
}
