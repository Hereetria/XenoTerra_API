using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Write
{
    public class WriteRepository<TEntity, TDtoResult, TKey> : IWriteRepository<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        private readonly IMapper _mapper;
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public WriteRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public AppDbContext GetDbContext()
        {
            return _context;
        }

        public async Task<TDtoResult> InsertAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "The entity to create cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return _mapper.Map<TDtoResult>(entity);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Insert failed: {ex.Message}");
                throw new InvalidOperationException("An error occurred while inserting the entity.", ex);
            }
        }

        public async Task<bool> RemoveAsync(TKey key)
        {
            if (key is null || (EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid)))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var entity = await _dbSet.FindAsync(key);
            if (entity is null)
                return false;

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Delete failed: {ex.Message}");
                throw new InvalidOperationException("An error occurred while deleting the entity.", ex);
            }
        }

        public async Task<TDtoResult> ModifyAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "The entity to update cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return _mapper.Map<TDtoResult>(entity);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Update failed: {ex.Message}");
                throw new InvalidOperationException("An error occurred while updating the entity.", ex);
            }
        }
    }
}
