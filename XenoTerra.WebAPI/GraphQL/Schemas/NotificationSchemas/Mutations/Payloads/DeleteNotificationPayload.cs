using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations.Payloads
{
    public record DeleteNotificationPayload : Payload<ResultNotificationDto>;
}
