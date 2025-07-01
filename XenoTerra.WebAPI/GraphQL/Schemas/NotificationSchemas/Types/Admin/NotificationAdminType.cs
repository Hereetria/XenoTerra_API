using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Types.Admin
{
    public class NotificationAdminType : ObjectType<ResultNotificationAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationAdminDto> descriptor)
        {
            descriptor.Name("ResultNotificationAdmin");
        }
    }
}
