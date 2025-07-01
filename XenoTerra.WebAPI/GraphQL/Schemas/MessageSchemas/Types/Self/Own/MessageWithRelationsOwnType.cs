using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Types.Self.Own
{
    public class MessageWithRelationsOwnType : ObjectType<ResultMessageWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultMessageWithRelationsOwn");
        }
    }
}
