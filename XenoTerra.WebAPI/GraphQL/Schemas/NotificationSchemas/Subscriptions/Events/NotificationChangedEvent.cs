using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Subscriptions.Events
{
    public record NotificationChangedEvent : ChangedEvent<ResultNotificationDto>
    {
    }
}