using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types.Self.Public
{
    public class HighlightWithRelationsPublicType : ObjectType<ResultHighlightWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultHighlightWithRelationsPublic");
        }
    }
}
