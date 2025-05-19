using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events
{
    public record MessageAdminDeletedEvent : DeletedEvent<ResultMessageDto>
    {
    }
}
