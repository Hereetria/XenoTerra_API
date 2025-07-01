using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types.Self.Own
{
    public class HighlightOwnType : ObjectType<ResultHighlightOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightOwnDto> descriptor)
        {
            descriptor.Name("ResultHighlightOwn");
        }
    }
}
