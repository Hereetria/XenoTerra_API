using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.SearchHistoryUser
{
    public class SearchHistoryUserMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new SearchHistoryUser")]
        public async Task<ResultSearchHistoryUserDto> CreateSearchHistoryUserAsync(CreateSearchHistoryUserDto createSearchHistoryUserDto, [Service] ISearchHistoryUserWriteService searchHistoryUserWriteService)
        {
            var result = await searchHistoryUserWriteService.CreateAsync(createSearchHistoryUserDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing SearchHistoryUser")]
        public async Task<ResultSearchHistoryUserDto> UpdateSearchHistoryUserAsync(UpdateSearchHistoryUserDto updateSearchHistoryUserDto, [Service] ISearchHistoryUserWriteService searchHistoryUserWriteService)
        {
            var result = await searchHistoryUserWriteService.UpdateAsync(updateSearchHistoryUserDto);
            return result;
        }

        [GraphQLDescription("Delete a SearchHistoryUser by ID")]
        public async Task<bool> DeleteSearchHistoryUserAsync(Guid id, [Service] ISearchHistoryUserWriteService searchHistoryUserWriteService)
        {
            var result = await searchHistoryUserWriteService.DeleteAsync(id);
            return result;
        }
    }
}
