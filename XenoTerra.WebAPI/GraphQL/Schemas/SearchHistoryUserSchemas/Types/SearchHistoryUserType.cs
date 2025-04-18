using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Types
{
    public class SearchHistoryUserType : ObjectType<ResultSearchHistoryUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryUserDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryUser");
        }
    }
}
