using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Types.Admin
{
    public class MessageWithRelationsAdminType : ObjectType<ResultMessageWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultMessageWithRelationsAdmin");
        }
    }
}
