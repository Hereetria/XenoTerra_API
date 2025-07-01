using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types.Self.Own
{
    public class HighlightWithRelationsOwnType : ObjectType<ResultHighlightWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultHighlightWithRelationsOwn");
        }
    }
}
