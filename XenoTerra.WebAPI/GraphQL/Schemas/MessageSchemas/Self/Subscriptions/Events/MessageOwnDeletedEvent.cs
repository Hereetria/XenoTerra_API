using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events
{
    public record MessageOwnDeletedEvent : DeletedEvent<ResultMessageOwnDto>
    {
    }
}
