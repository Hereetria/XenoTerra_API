

using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Base
{
    public abstract class EntityDataLoader<TRelatedEntity, TKey> : BatchDataLoader<TKey, TRelatedEntity>, IEntityDataLoader<TKey, TRelatedEntity>
        where TRelatedEntity : class
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

        public async Task<IReadOnlyDictionary<TKey, TRelatedEntity>> LoadAsync(List<TKey> keys, List<string> selectedFields)
        {
            _selectedFields = selectedFields;

            return await LoadBatchAsync(keys, CancellationToken.None);
        }

        protected override async Task<IReadOnlyDictionary<TKey, TRelatedEntity>> LoadBatchAsync(IReadOnlyList<TKey> keys, CancellationToken cancellationToken)
        {
            var entityDict = new Dictionary<TKey, TRelatedEntity>();
            var primaryKeyProperty = TypeProviders.GetPrimaryKeyProperty<TRelatedEntity>(_dbContext);

            if (primaryKeyProperty == null)
            {
                throw new InvalidOperationException($"Primary key property not found for {typeof(TRelatedEntity).Name}");
            }

            var selectedFields = _selectedFields ?? new List<string>();

            if (!selectedFields.Any(f => f.Equals(primaryKeyProperty.Name, StringComparison.OrdinalIgnoreCase)))
            {
                selectedFields.Add(primaryKeyProperty.Name);
            }

            var selector = CreateSelectorExpression(selectedFields);

            var keySet = new HashSet<TKey>(keys);

            var query = _dbContext.Set<TRelatedEntity>()
                                  .Where(e => keySet.Contains(EF.Property<TKey>(e, primaryKeyProperty.Name)))
                                  .Select(selector);

            var results = await query.ToListAsync(cancellationToken);

            entityDict = results
                .Select(entity => new { Key = primaryKeyProperty.GetValue(entity), Entity = entity })
                .Where(x => x.Key != null && x.Key is TKey)
                .ToDictionary(x => (TKey)x.Key!, x => x.Entity);

            return entityDict;
        }



        private static Expression<Func<TRelatedEntity, TRelatedEntity>> CreateSelectorExpression(List<string> selectedFields)
        {
            var entityParameter = Expression.Parameter(typeof(TRelatedEntity), "entity");
            var dtoParameter = Expression.New(typeof(TRelatedEntity));

            var bindings = new List<MemberBinding>();
            var entityProperties = typeof(TRelatedEntity).GetProperties();

            foreach (var field in selectedFields)
            {
                var entityProperty = entityProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                if (entityProperty != null)
                {
                    var entityPropertyExpression = Expression.Property(entityParameter, entityProperty);
                    var binding = Expression.Bind(entityProperty, entityPropertyExpression);
                    bindings.Add(binding);
                }
            }

            var body = Expression.MemberInit(dtoParameter, bindings);
            return Expression.Lambda<Func<TRelatedEntity, TRelatedEntity>>(body, entityParameter);
        }


    }
}
