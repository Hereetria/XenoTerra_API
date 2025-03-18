using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Base
{
    public abstract class EntityDataLoader<TEntity, TDtoResult, TKey> : BatchDataLoader<TKey, TDtoResult>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private static List<string> _selectedFields = new();
        public EntityDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            IMapper mapper,
            AppDbContext dbContext)
                : base(batchScheduler, options)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyDictionary<TKey, TDtoResult>> LoadAsync(List<TKey> keys, List<string> selectedFields)
        {
            _selectedFields = selectedFields;

            return await LoadBatchAsync(keys, CancellationToken.None);
        }

        protected override async Task<IReadOnlyDictionary<TKey, TDtoResult>> LoadBatchAsync(IReadOnlyList<TKey> keys, CancellationToken cancellationToken)
        {
            var entityDict = new Dictionary<TKey, TDtoResult>();
            var primaryKeyProperty = TypeProviders.GetPrimaryKeyProperty<TEntity>(_dbContext)
                ?? throw new InvalidOperationException($"Primary key property not found for {typeof(TEntity).Name}");

            var selectedFields = _selectedFields ?? new List<string>();

            if (!selectedFields.Any(f => f.Equals(primaryKeyProperty.Name, StringComparison.OrdinalIgnoreCase)))
                selectedFields.Add(primaryKeyProperty.Name);
            

            var selector = CreateSelectorExpression(selectedFields);

            var keySet = new HashSet<TKey>(keys);

            var query = _dbContext.Set<TEntity>()
                                  .Where(e => keySet.Contains(EF.Property<TKey>(e, primaryKeyProperty.Name)))
                                  .Select(selector);

            var entities = await query.ToListAsync(cancellationToken);

            var dtoResults = _mapper.Map<List<TDtoResult>>(entities);

            entityDict = dtoResults
                .Select(entity => new { Key = primaryKeyProperty.GetValue(entity), Entity = entity })
                .Where(x => x.Key != null && x.Key is TKey)
                .ToDictionary(x => (TKey)x.Key!, x => x.Entity);

            return entityDict;
        }



        private static Expression<Func<TEntity, TEntity>> CreateSelectorExpression(List<string> selectedFields)
        {
            var entityParameter = Expression.Parameter(typeof(TEntity), "entity");
            var dtoParameter = Expression.New(typeof(TEntity));

            var bindings = new List<MemberBinding>();
            var entityProperties = typeof(TEntity).GetProperties();

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
            return Expression.Lambda<Func<TEntity, TEntity>>(body, entityParameter);
        }


    }
}
