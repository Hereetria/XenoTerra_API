using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Types.Admin
{
    public class MessageAdminType : ObjectType<ResultMessageAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageAdminDto> descriptor)
        {
            descriptor.Name("ResultMessageAdmin");
        }
    }
}
