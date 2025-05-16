using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events
{
    public record MessageDeletedAdminEvent : DeletedAdminEvent<ResultMessageDto>
    {
    }
}
