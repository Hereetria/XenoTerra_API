using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types.Self.Public
{
    public class HighlightPublicType : ObjectType<ResultHighlightPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightPublicDto> descriptor)
        {
            descriptor.Name("ResultHighlightPublic");
        }
    }
}
