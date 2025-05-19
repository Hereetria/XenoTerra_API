using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events
{
    public record NotificationAdminChangedEvent : ChangedEvent<ResultNotificationDto>
    {
    }
}