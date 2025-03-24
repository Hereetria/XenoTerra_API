using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Base
{
    public abstract class EntityDataLoader<TEntity, TKey> : BatchDataLoader<TKey, TEntity>
        where TEntity : class
        where TKey : notnull
    {
        private readonly AppDbContext _dbContext;
        private static List<string> _selectedFields = new();
        public EntityDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            AppDbContext dbContext)
                : base(batchScheduler, options)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyDictionary<TKey, TEntity>> LoadAsync(List<TKey> keys, List<string> selectedFields)
        {
            _selectedFields = selectedFields;

            return await LoadBatchAsync(keys, CancellationToken.None);
        }

        protected override async Task<IReadOnlyDictionary<TKey, TEntity>> LoadBatchAsync(IReadOnlyList<TKey> keys, CancellationToken cancellationToken)
        {
            var entityDict = new Dictionary<TKey, TEntity>();
            var primaryKeyProperty = TypeProviders.GetPrimaryKeyProperty<TEntity>(_dbContext)
                ?? throw new InvalidOperationException($"Primary key property not found for {typeof(TEntity).Name}");

            var selectedFields = _selectedFields ?? new List<string>();

            if (!selectedFields.Any(f => f.Equals(primaryKeyProperty.Name, StringComparison.OrdinalIgnoreCase)))
                selectedFields.Add(primaryKeyProperty.Name);
            

            var selector = SimpleProjectonExpressionProvider.CreateSelectorExpression<TEntity>(selectedFields);

            var keySet = new HashSet<TKey>(keys);

            var query = _dbContext.Set<TEntity>()
                                  .Where(e => keySet.Contains(EF.Property<TKey>(e, primaryKeyProperty.Name)))
                                  .Select(selector);

            var entities = await query.ToListAsync(cancellationToken);


            var entityPrimaryKeyProperty = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(primaryKeyProperty.Name, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"Primary key property not found in DTO {typeof(TEntity).Name}");

            entityDict = entities
                .Select(entity => new { Key = entityPrimaryKeyProperty.GetValue(entity), Entity = entity })
                .Where(x => x.Key != null && x.Key is TKey)
                .ToDictionary(x => (TKey)x.Key!, x => x.Entity);

            return entityDict;
        }
    }
}
