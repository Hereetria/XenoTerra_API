using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events
{
    public record NotificationOwnUpdatedEvent : UpdatedEvent<ResultNotificationOwnDto>
    {
    }
}