using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Types
{
    public class NotificationType : ObjectType<ResultNotificationDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationDto> descriptor)
        {
            descriptor.Name("ResultNotification");
        }
    }
}
