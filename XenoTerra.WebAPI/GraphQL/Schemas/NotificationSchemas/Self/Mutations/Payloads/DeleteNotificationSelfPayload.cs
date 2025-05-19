using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Payloads
{
    public record DeleteNotificationSelfPayload : Payload<ResultNotificationDto>;
}
