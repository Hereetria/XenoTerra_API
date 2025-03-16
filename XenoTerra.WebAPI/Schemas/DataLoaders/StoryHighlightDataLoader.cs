using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class StoryHighlightDataLoader : BatchDataLoader<TKey, TRelatedEntity>
        where TLeftRelatedEntity : class
        where TRightRelatedEntity : class
        where TKey : notnull
    {
        private readonly AppDbContext _dbContext;
        private static List<string> _selectedFields = new();
        private Type? _lastLoadedType;

        public StoryHighlightDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options,
            AppDbContext context)
                : base(batchScheduler, options)
        {
            _dbContext = context;
        }

        public async Task<IReadOnlyDictionary<Guid, List<TRelatedEntity>>> Loadsync<TRelatedEntity>(TKey key, List<string> selectedFields)
            where TRelatedEntity : class
        {
            _selectedFields = selectedFields;
            _lastLoadedType = typeof(TRelatedEntity);

            var batchResult =  await LoadBatchAsync(new List<TKey> { key }, CancellationToken.None);


            return batchResult.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Cast<ResultStoryDto>().ToList()
            );
        }

        public async Task<IReadOnlyDictionary<Guid, List<ResultHighlightDto>>> LoadHighlightsByStoryIdAsync(TKey key, List<string> selectedFields)
        {
            _selectedFields = selectedFields;
            _lastLoadedType = typeof(ResultHighlightDto);

            var batchResult = await LoadBatchAsync(new List<TKey> { key }, CancellationToken.None);

            return batchResult.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Cast<ResultHighlightDto>().ToList()
            );
        }

        protected override async Task<IReadOnlyDictionary<TKey, IReadOnlyList<object>>> LoadBatchAsync(
            IReadOnlyList<TKey> keys, CancellationToken cancellationToken)
        {
            var entityDict = new Dictionary<TKey, IReadOnlyList<TRelatedEntity>>();

            var singleKey = keys.First();

            bool isStoryForHighlightRequest = _lastLoadedType == typeof(ResultStoryDto);

            if (isStoryForHighlightRequest)
            {
                var selectorExpression = SelectorExpressionProvider.GetSelectorExpression<Story, ResultStoryDto>(selectedFieldsList);

                var storiesQuery = _dbContext.Stories
                    .Join(_dbContext.StoryHighlights,
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
