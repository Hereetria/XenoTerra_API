using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Types
{
    public class SearchHistoryUserWithRelationsType : ObjectType<ResultSearchHistoryUserWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryUserWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryUserWithRelations");
        }
    }
}
