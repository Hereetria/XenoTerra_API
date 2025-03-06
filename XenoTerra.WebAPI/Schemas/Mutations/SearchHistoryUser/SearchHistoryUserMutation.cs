using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.SearchHistoryUser
{
    public class SearchHistoryUserMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new SearchHistoryUser")]
        public async Task<ResultSearchHistoryUserDto> CreateSearchHistoryUserAsync(CreateSearchHistoryUserDto createSearchHistoryUserDto, [Service] ISearchHistoryUserServiceBLL searchHistoryUserServiceBLL)
        {
            var result = await searchHistoryUserServiceBLL.CreateAsync(createSearchHistoryUserDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing SearchHistoryUser")]
        public async Task<ResultSearchHistoryUserDto> UpdateSearchHistoryUserAsync(UpdateSearchHistoryUserDto updateSearchHistoryUserDto, [Service] ISearchHistoryUserServiceBLL searchHistoryUserServiceBLL)
        {
            var result = await searchHistoryUserServiceBLL.UpdateAsync(updateSearchHistoryUserDto);
            return result;
        }

        [GraphQLDescription("Delete a SearchHistoryUser by ID")]
        public async Task<bool> DeleteSearchHistoryUserAsync(Guid id, [Service] ISearchHistoryUserServiceBLL searchHistoryUserServiceBLL)
        {
            var result = await searchHistoryUserServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
