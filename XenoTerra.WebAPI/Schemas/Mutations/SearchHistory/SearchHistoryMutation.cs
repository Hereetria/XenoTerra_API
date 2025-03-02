using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.SearchHistory
{
    public class SearchHistoryMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new SearchHistory")]
        public async Task<ResultSearchHistoryByIdDto> CreateSearchHistoryAsync(CreateSearchHistoryDto createSearchHistoryDto, [Service] ISearchHistoryServiceBLL searchHistoryServiceBLL)
        {
            var result = await searchHistoryServiceBLL.CreateAsync(createSearchHistoryDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing SearchHistory")]
        public async Task<ResultSearchHistoryByIdDto> UpdateSearchHistoryAsync(UpdateSearchHistoryDto updateSearchHistoryDto, [Service] ISearchHistoryServiceBLL searchHistoryServiceBLL)
        {
            var result = await searchHistoryServiceBLL.UpdateAsync(updateSearchHistoryDto);
            return result;
        }

        [GraphQLDescription("Delete a SearchHistory by ID")]
        public async Task<bool> DeleteSearchHistoryAsync(Guid id, [Service] ISearchHistoryServiceBLL searchHistoryServiceBLL)
        {
            var result = await searchHistoryServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
