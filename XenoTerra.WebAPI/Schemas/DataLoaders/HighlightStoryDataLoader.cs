using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class HighlightStoryDataLoader : BatchDataLoader<Guid, IReadOnlyList<object>>
    {
        private static readonly ConcurrentDictionary<Guid, List<string>> _selectedFieldsDict = new();
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private Type? _lastLoadedType;

        public HighlightStoryDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            IDbContextFactory<AppDbContext> contextFactory)
                : base(batchScheduler, options)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyDictionary<Guid, List<ResultStoryDto>>> LoadStoriesByHighlightIdAsync(Guid highlightId, List<string> selectedFields)
        {
            _selectedFieldsDict[highlightId] = selectedFields;
            _lastLoadedType = typeof(ResultStoryDto);

            var batchResult = await LoadBatchAsync(new List<Guid> { highlightId }, CancellationToken.None);

            var resultList = batchResult.Values.FirstOrDefault() is List<object> list
                ? list.Cast<ResultStoryDto>().ToList()
                : new List<ResultStoryDto>();



            return batchResult.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Cast<ResultStoryDto>().ToList()
            );
        }

        public async Task<IReadOnlyDictionary<Guid, List<ResultHighlightDto>>> LoadHighlightsByStoryIdAsync(Guid storyId, List<string> selectedFields)
        {
            _selectedFieldsDict[storyId] = selectedFields;
            _lastLoadedType = typeof(ResultHighlightDto);

            var batchResult = await LoadBatchAsync(new List<Guid> { storyId }, CancellationToken.None);

            return batchResult.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Cast<ResultHighlightDto>().ToList()
            );
        }

        protected override async Task<IReadOnlyDictionary<Guid, IReadOnlyList<object>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var resultDict = new Dictionary<Guid, IReadOnlyList<object>>();

            var singleKey = keys.First();
            _selectedFieldsDict.TryGetValue(singleKey, out var selectedFieldsList);
            selectedFieldsList ??= new List<string>();

            bool isStoryForHighlightRequest = _lastLoadedType == typeof(ResultStoryDto);

            if (isStoryForHighlightRequest)
            {
                var selectorExpression = SelectorExpressionProvider.GetSelectorExpression<Story, ResultStoryDto>(selectedFieldsList);

                var storiesQuery = context.Stories
                    .Join(context.StoryHighlights,
                        s => s.StoryId,
                        sh => sh.StoryId,
                        (s, sh) => new { Story = s, HighlightId = sh.HighlightId })
                    .Where(joined => joined.HighlightId == singleKey)
                    .Select(joined => joined.Story)
                    .Select(selectorExpression);

                var stories = await storiesQuery.ToListAsync(cancellationToken);

                resultDict[singleKey] = stories.Cast<object>().ToList();
            }
            else
            {
                var selectorExpression = SelectorExpressionProvider.GetSelectorExpression<Highlight, ResultHighlightDto>(selectedFieldsList);

                var highlightsQuery = context.Highlights
                    .Join(context.StoryHighlights,
                        h => h.HighlightId,
                        sh => sh.HighlightId,
                        (h, sh) => new { Highlight = h, StoryId = sh.StoryId })
                    .Where(joined => joined.StoryId == singleKey)
                    .Select(joined => joined.Highlight)
                    .Select(selectorExpression);

                var highlights = await highlightsQuery.ToListAsync(cancellationToken);

                resultDict[singleKey] = highlights.Cast<object>().ToList();
            }

            return resultDict;
        }

    }

}
