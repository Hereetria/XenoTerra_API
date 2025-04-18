using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types
{
    public class HighlightWithRelationsType : ObjectType<ResultHighlightWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultHighlightWithRelations");
        }
    }
}
