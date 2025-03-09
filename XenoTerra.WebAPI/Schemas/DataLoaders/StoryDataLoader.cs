using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class StoryDataLoader : BatchDataLoader<Guid, ResultStoryDto>
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private static readonly ConcurrentDictionary<Guid, List<string>> _fieldsCache = new();
        private static readonly ConcurrentDictionary<string, LambdaExpression> _expressionCache = new();

        public StoryDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            IDbContextFactory<AppDbContext> contextFactory)
                : base(batchScheduler, options)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyDictionary<Guid, ResultStoryDto>> LoadAsync(List<Guid> storyIds, List<string> selectedFields)
        {
            foreach (var storyId in storyIds)
            {
                _fieldsCache[storyId] = selectedFields;
            }
            return await LoadBatchAsync(storyIds, CancellationToken.None);
        }

        protected override async Task<IReadOnlyDictionary<Guid, ResultStoryDto>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var fieldGroups = keys
                .Select(key => new { Key = key, Fields = _fieldsCache.ContainsKey(key) ? _fieldsCache[key] : new List<string>() })
                .GroupBy(x => string.Join(",", x.Fields.OrderBy(f => f)), x => x.Key)
                .ToDictionary(g => g.Key, g => g.ToList());

            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var storiesDict = new Dictionary<Guid, ResultStoryDto>();

            foreach (var fieldGroup in fieldGroups)
            {
                var selectedFields = fieldGroup.Key.Split(',').ToList();

                if (!selectedFields.Any(f => f.Equals(nameof(ResultStoryDto.StoryId), StringComparison.OrdinalIgnoreCase)))
                {
                    selectedFields.Add(nameof(ResultStoryDto.StoryId));
                }

                var selector = CreateSelectorExpression(selectedFields);

                var groupResults = await context.Stories
                    .Where(story => fieldGroup.Value.Contains(story.StoryId))
                    .Select(selector)
                    .ToDictionaryAsync(story => story.StoryId, cancellationToken);

                foreach (var kvp in groupResults)
                {
                    storiesDict[kvp.Key] = kvp.Value;
                }
            }

            return storiesDict;
        }

        private static Expression<Func<Story, ResultStoryDto>> CreateSelectorExpression(List<string> selectedFields)
        {
            var cacheKey = string.Join(",", selectedFields.OrderBy(f => f));

            if (_expressionCache.TryGetValue(cacheKey, out var cachedExpression))
            {
                return (Expression<Func<Story, ResultStoryDto>>)cachedExpression;
            }

            var storyParameter = Expression.Parameter(typeof(Story), "story");
            var dtoParameter = Expression.New(typeof(ResultStoryDto));

            var bindings = new List<MemberBinding>();
            var storyProperties = typeof(Story).GetProperties();
            var dtoProperties = typeof(ResultStoryDto).GetProperties();

            foreach (var field in selectedFields)
            {
                var entityProperty = storyProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                var dtoProperty = dtoProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                if (entityProperty != null && dtoProperty != null)
                {
                    var storyPropertyExpression = Expression.Property(storyParameter, entityProperty);
                    var binding = Expression.Bind(dtoProperty, storyPropertyExpression);
                    bindings.Add(binding);
                }
            }

            var body = Expression.MemberInit(dtoParameter, bindings);
            var expression = Expression.Lambda<Func<Story, ResultStoryDto>>(body, storyParameter);

            _expressionCache[cacheKey] = expression; // 🏷 Expression önbelleğe alındı

            return expression;
        }
    }

}
