

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Contexts;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Utils;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using HotChocolate;
using XenoTerra.DataAccessLayer.Services.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace XenoTerra.DataAccessLayer.Repositories
{
    
    public class GenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey> : IGenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultWithRelationsDto : class
        where TCreateDto : class
        where TUpdateDto : class

    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public GenericRepositoryDAL(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Guid>> TGetAllIdsAsync()
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            var keyProperty = primaryKey.Properties[0];

            var result = await _context.Set<TEntity>()
                .Select(entity => EF.Property<Guid>(entity, keyProperty.Name))
                .ToListAsync();

            return result;
        }


        public IQueryable<TResultDto> TGetByIdsQuerable(IEnumerable<Guid> ids)
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            var keyProperty = primaryKey.Properties[0];

            return _context.Set<TEntity>()
                .Where(entity => ids.Contains(EF.Property<Guid>(entity, keyProperty.Name)))
                .ProjectTo<TResultDto>(_mapper.ConfigurationProvider);
        }


        public async Task<IEnumerable<TResultWithRelationsDto>> TGetByIdsWithRelationsAsync(IReadOnlyCollection<Guid>? ids, IReadOnlyCollection<string> selectedFields)
        {
            if (ids == null || !ids.Any())
                return await GetAllWithRelationsAsync(selectedFields);

            var entityType = _context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException("Entity type not found in the current DbContext model.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException("This method only supports entities with a single primary key.");

            var idSet = new HashSet<Guid>(ids);
            var selector = CreateSelectorExpression(selectedFields);

            var result = await _context.Set<TEntity>()
                .AsNoTracking()
                .Where(entity => idSet.Contains(EF.Property<Guid>(entity, primaryKey.Properties[0].Name)))
                .Select(selector)
                .ToListAsync();

            return result;
        }

        private async Task<IEnumerable<TResultWithRelationsDto>> GetAllWithRelationsAsync(IEnumerable<string> selectedFields)
        {
            var selector = CreateSelectorExpression(selectedFields);

            var result = await _context.Set<TEntity>()
                .AsNoTracking()
                .Select(selector)
                .ToListAsync();

            return result;
        }

        private Expression<Func<TEntity, TResultWithRelationsDto>> CreateSelectorExpression(IEnumerable<string> selectedFields)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var bindings = new List<MemberBinding>();

            var selectedFieldsSet = new HashSet<string>(selectedFields, StringComparer.OrdinalIgnoreCase);
            var fieldQueue = new Queue<string>(selectedFieldsSet);

            var entityType = _context.Model.FindEntityType(typeof(TEntity));

            while (fieldQueue.Count > 0)
            {
                var field = fieldQueue.Dequeue();
                var dtoProperty = typeof(TResultWithRelationsDto).GetProperties()
                    .FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                if (dtoProperty == null) continue;

                ProcessNavigationProperty(dtoProperty, entityType, selectedFieldsSet, fieldQueue);

                if (dtoProperty != null &&
                    (dtoProperty.PropertyType.IsPrimitive || // int, bool, double vs.
                     dtoProperty.PropertyType == typeof(string) ||
                     dtoProperty.PropertyType == typeof(Guid)))

                {
                    var entityProperty = Expression.Property(parameter, field);
                    var binding = Expression.Bind(dtoProperty, entityProperty);
                    bindings.Add(binding);
                }
            }

            var body = Expression.MemberInit(Expression.New(typeof(TResultWithRelationsDto)), bindings);
            return Expression.Lambda<Func<TEntity, TResultWithRelationsDto>>(body, parameter);
        }

        

        public async Task<TResultDto> TCreateAsync(TCreateDto createDto)
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

                var result = _mapper.Map<TResultDto>(entity);
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

        public async Task<TResultDto> TUpdateAsync(TUpdateDto updateDto)
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

                var result = _mapper.Map<TResultDto>(existingEntity);
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

        private void ProcessNavigationProperty(
            PropertyInfo dtoProperty,
            IEntityType? entityType,
            HashSet<string> selectedFieldsSet,
            Queue<string> fieldQueue)
        {
            if (dtoProperty.PropertyType.IsClass && dtoProperty.PropertyType != typeof(string))
            {
                var navigation = entityType?.FindNavigation(dtoProperty.Name);
                var foreignKey = navigation?.ForeignKey?.Properties.FirstOrDefault();

                if (foreignKey != null)
                {
                    var idPropertyName = foreignKey.Name;

                    if (selectedFieldsSet.Add(idPropertyName))
                    {
                        fieldQueue.Enqueue(idPropertyName);
                    }
                }
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