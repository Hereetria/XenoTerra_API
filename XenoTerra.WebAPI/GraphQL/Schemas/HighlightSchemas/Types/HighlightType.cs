using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types
{
    public class HighlightType : ObjectType<ResultHighlightDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightDto> descriptor)
        {
            descriptor.Name("ResultHighlight");
        }
    }
}
