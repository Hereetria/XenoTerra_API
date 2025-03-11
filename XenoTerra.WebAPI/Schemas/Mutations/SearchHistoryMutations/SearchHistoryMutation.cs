using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.SearchHistoryMutations
{
    public class SearchHistoryMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new SearchHistory")]
        public async Task<ResultSearchHistoryDto> CreateSearchHistoryAsync(CreateSearchHistoryDto createSearchHistoryDto, [Service] ISearchHistoryWriteService searchHistoryWriteService)
        {
            var result = await searchHistoryWriteService.CreateAsync(createSearchHistoryDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing SearchHistory")]
        public async Task<ResultSearchHistoryDto> UpdateSearchHistoryAsync(UpdateSearchHistoryDto updateSearchHistoryDto, [Service] ISearchHistoryWriteService searchHistoryWriteService)
        {
            var result = await searchHistoryWriteService.UpdateAsync(updateSearchHistoryDto);
            return result;
        }

        [GraphQLDescription("Delete a SearchHistory by ID")]
        public async Task<bool> DeleteSearchHistoryAsync(Guid id, [Service] ISearchHistoryWriteService searchHistoryWriteService)
        {
            var result = await searchHistoryWriteService.DeleteAsync(id);
            return result;
        }
    }
}
