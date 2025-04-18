using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Types
{
    public class MessageWithRelationsType : ObjectType<ResultMessageWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultMessageWithRelations");
        }
    }
}
