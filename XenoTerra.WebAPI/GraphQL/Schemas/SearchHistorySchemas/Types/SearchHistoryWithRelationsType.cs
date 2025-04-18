using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Types
{
    public class SearchHistoryWithRelationsType : ObjectType<ResultSearchHistoryWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryWithRelations");
        }
    }
}
