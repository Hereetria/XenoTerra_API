using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistoryQueries
{
    public class SearchHistoryQuery
    {
        private readonly IMapper _mapper;

        public SearchHistoryQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultSearchHistoryWithRelationsDto>> GetAllSearchHistoriesAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var searchHistories = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(searchHistories, context);
            var searchHistoryDtos = _mapper.Map<List<ResultSearchHistoryWithRelationsDto>>(searchHistories);
            return searchHistoryDtos;
        }

        public async Task<IEnumerable<ResultSearchHistoryWithRelationsDto>> GetSearchHistoriesByIdsAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var searchHistories = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(searchHistories, context);
            var searchHistoryDtos = _mapper.Map<List<ResultSearchHistoryWithRelationsDto>>(searchHistories);
            return searchHistoryDtos;
        }

        public async Task<ResultSearchHistoryWithRelationsDto> GetSearchHistoryByIdAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var searchHistory = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(searchHistory, context);
            var searchHistoryDto = _mapper.Map<ResultSearchHistoryWithRelationsDto>(searchHistory);
            return searchHistoryDto;
        }
    }

}
