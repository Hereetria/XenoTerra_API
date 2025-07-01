using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Types.Self.Own
{
    public class MessageOwnType : ObjectType<ResultMessageOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageOwnDto> descriptor)
        {
            descriptor.Name("ResultMessageOwn");
        }
    }
}
