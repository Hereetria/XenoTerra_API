

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Contexts;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;

namespace XenoTerra.DataAccessLayer.Repositories
{
    
    public class GenericRepositoryDAL<TEntity, TResultDto, TResultById, TCreateDto, TUpdateDto, TKey> : IGenericRepositoryDAL<TEntity, TResultDto, TResultById, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TResultDto : class
        where TResultById : class

    {

        protected readonly Context _context;
        protected readonly IMapper _mapper;

        public GenericRepositoryDAL(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<TResultDto> TGetAllQueryable()
        {
            return _context.Set<TEntity>()
                           .AsNoTracking()
                           .ProjectTo<TResultDto>(_mapper.ConfigurationProvider);
        }

        public IQueryable<TResultById> TGetByIdQuerable(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                             ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            var keyPropertyName = primaryKey.Properties[0].Name;
            if (string.IsNullOrEmpty(keyPropertyName))
                throw new InvalidOperationException("Primary key property name is null or empty.");

            return _context.Set<TEntity>()
                           .AsNoTracking()
                           .Where(entity => EF.Property<TKey>(entity, keyPropertyName).Equals(id))
                           .ProjectTo<TResultById>(_mapper.ConfigurationProvider);
        }


        public async Task<TResultById> TGetByIdAsync(TKey id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id), "ID cannot be null.");
                }

                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Record with ID {id} not found.");
                }

                var result = _mapper.Map<TResultById>(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the record: {ex.Message}");
            }
        }

        public async Task<TResultById> TCreateAsync(TCreateDto createDto)
        {
            try
            {
                if (createDto == null)
                {
                    throw new ArgumentNullException(nameof(createDto), "The entity to create cannot be null.");
                }

                var entity = _mapper.Map<TEntity>(createDto);
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();

                var result = _mapper.Map<TResultById>(entity);
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"An error occurred while saving to the database: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the entity: {ex.Message}");
            }
        }

        public async Task<TResultById> TUpdateAsync(TUpdateDto updateDto)
        {
            if (updateDto == null)
                throw new ArgumentNullException(nameof(updateDto), "The entity to update cannot be null.");

            try
            {
                var entity = _mapper.Map<TEntity>(updateDto);
                var entityId = GetEntityId(entity);

                var existingEntity = await _context.Set<TEntity>().FindAsync(entityId)
                    ?? throw new Exception("Entity not found. It might have been deleted.");

                _mapper.Map(updateDto, existingEntity);
                await _context.SaveChangesAsync();

                var result = _mapper.Map<TResultById>(existingEntity);
                return result;
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException || ex is DbUpdateException)
            {
                throw new Exception($"Database update error: {ex.Message}");
            }
        }

        public async Task<bool> TDeleteAsync(TKey id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id), "ID cannot be null.");
                }

                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"An error occurred while deleting from the database: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the entity: {ex.Message}");
            }
        }

        public async Task<List<TResultQueryDto>> TGetEntitiesByQueryAsync<TResultQueryDto>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
            where TResultQueryDto : class
        {
            try
            {
                var entities = await query(_context.Set<TEntity>()).ToListAsync();

                return entities != null
                    ? _mapper.Map<List<TResultQueryDto>>(entities)
                    : new List<TResultQueryDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving entities: {ex.Message}");
            }
        }

        public async Task<TResultQueryDto?> TGetEntityByQueryAsync<TResultQueryDto>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
            where TResultQueryDto : class
        {
            try
            {
                var entity = await query(_context.Set<TEntity>())
                    .FirstOrDefaultAsync();

                return entity != null
                    ? _mapper.Map<TResultQueryDto>(entity)
                    : default;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public async Task<List<TResultQueryDto>> TGetSelectedEntitiesByQueryAsync<TResultQueryDto, TResultEntity>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
            Expression<Func<TEntity, TResultEntity>> selectExpression)
            where TResultQueryDto : class
            where TResultEntity : class
        {
            try
            {
                var result = query(_context.Set<TEntity>());

                var selectedEntity = await result
                    .Select(selectExpression)
                    .ToListAsync();

                return _mapper.Map<List<TResultQueryDto>>(selectedEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        private static object GetEntityId(TEntity entity)
        {
            return typeof(TEntity).GetProperty("Id")?.GetValue(entity)
                ?? throw new Exception("Entity does not have a valid 'Id' property.");
        }
    }
}