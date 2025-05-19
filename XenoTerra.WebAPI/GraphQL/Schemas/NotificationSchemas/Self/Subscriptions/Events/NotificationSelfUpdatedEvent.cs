using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events
{
    public record NotificationSelfUpdatedEvent : UpdatedEvent<ResultNotificationDto>
    {
    }
}