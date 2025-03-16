using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistoryUserQueries
{
    public class SearchHistoryUserQuery
    {
        public async Task<IEnumerable<ResultSearchHistoryUserWithRelationsDto>> GetAllSearchHistoryUsersAsync(
            [Service] ISearchHistoryUserReadService searchHistoryUserReadService,
            [Service] SearchHistoryUserResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = searchHistoryUserReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<SearchHistoryUser>().AsQueryable();

            var searchHistoryUsers = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(searchHistoryUsers, context);

            return mapper.Map<List<ResultSearchHistoryUserWithRelationsDto>>(searchHistoryUsers);
        }

        public async Task<IEnumerable<ResultSearchHistoryUserWithRelationsDto>> GetSearchHistoryUsersByIdsAsync(
            [Service] ISearchHistoryUserReadService searchHistoryUserReadService,
            [Service] SearchHistoryUserResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = searchHistoryUserReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<SearchHistoryUser>().AsQueryable();

            var searchHistoryUsers = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(searchHistoryUsers, context);

            return mapper.Map<List<ResultSearchHistoryUserWithRelationsDto>>(searchHistoryUsers);
        }

        public async Task<ResultSearchHistoryUserWithRelationsDto> GetSearchHistoryUserByIdAsync(
            [Service] ISearchHistoryUserReadService searchHistoryUserReadService,
            [Service] SearchHistoryUserResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = searchHistoryUserReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<SearchHistoryUser>().AsQueryable();

            var searchHistoryUser = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"SearchHistoryUser with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(searchHistoryUser, context);

            return mapper.Map<ResultSearchHistoryUserWithRelationsDto>(searchHistoryUser);
        }

    }
}
