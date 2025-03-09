using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Abstract;

namespace XenoTerra.DataAccessLayer.Repositories.Concrete
{
    class WriteRepository<TEntity, TKey> : IWriteRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly AppDbContext _context;

        public WriteRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "The entity to create cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Insert failed: {ex.Message}");
                throw;
            }
        }

        public async Task<TEntity> ModifyAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "The entity to update cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Update failed: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> RemoveAsync(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null.");

            var entity = await _context.Set<TEntity>().FindAsync(key);
            if (entity == null)
                return false; // 🔹 Eğer kayıt bulunamazsa işlem yapılmaz, false döneriz.

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true; // 🔹 Silme başarılıysa true döndür
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Delete failed: {ex.Message}");
                throw;
            }
        }
    }
}
