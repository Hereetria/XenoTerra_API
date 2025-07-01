using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events
{
    public record NotificationAdminDeletedEvent : DeletedEvent<ResultNotificationAdminDto>
    {
    }
}