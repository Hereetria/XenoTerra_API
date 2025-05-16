using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events
{
    public record NotificationUpdatedAdminEvent : UpdatedAdminEvent<ResultNotificationDto>
    {
    }
}