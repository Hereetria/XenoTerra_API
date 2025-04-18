using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Types
{
    public class SearchHistoryType : ObjectType<ResultSearchHistoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryDto> descriptor)
        {
            descriptor.Name("ResultSearchHistory");
        }
    }
}
