using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistoryQueries
{
    public class SearchHistoryQuery
    {
        public async Task<IEnumerable<ResultSearchHistoryWithRelationsDto>> GetAllSearchHistoriesAsync(
            [Service] ISearchHistoryReadService searchHistoryReadService,
            [Service] SearchHistoryResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = searchHistoryReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<SearchHistory>().AsQueryable();

            var searchHistories = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(searchHistories, context);

            return mapper.Map<List<ResultSearchHistoryWithRelationsDto>>(searchHistories);
        }

        public async Task<IEnumerable<ResultSearchHistoryWithRelationsDto>> GetSearchHistoriesByIdsAsync(
            [Service] ISearchHistoryReadService searchHistoryReadService,
            [Service] SearchHistoryResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = searchHistoryReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<SearchHistory>().AsQueryable();

            var searchHistories = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(searchHistories, context);

            return mapper.Map<List<ResultSearchHistoryWithRelationsDto>>(searchHistories);
        }

        public async Task<ResultSearchHistoryWithRelationsDto> GetSearchHistoryByIdAsync(
            [Service] ISearchHistoryReadService searchHistoryReadService,
            [Service] SearchHistoryResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = searchHistoryReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<SearchHistory>().AsQueryable();

            var searchHistory = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"SearchHistory with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(searchHistory, context);

            return mapper.Map<ResultSearchHistoryWithRelationsDto>(searchHistory);
        }

    }
}
