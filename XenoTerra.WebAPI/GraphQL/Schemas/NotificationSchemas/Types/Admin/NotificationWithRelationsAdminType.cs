using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Types.Admin
{
    public class NotificationWithRelationsAdminType : ObjectType<ResultNotificationWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultNotificationWithRelationsAdmin");
        }
    }
}
