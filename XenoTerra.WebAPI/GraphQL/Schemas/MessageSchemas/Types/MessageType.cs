using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Types
{
    public class MessageType : ObjectType<ResultMessageDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageDto> descriptor)
        {
            descriptor.Name("ResultMessage");
        }
    }
}
