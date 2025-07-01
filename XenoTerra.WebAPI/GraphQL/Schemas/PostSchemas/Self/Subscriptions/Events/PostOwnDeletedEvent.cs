using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events
{
    public record PostOwnDeletedEvent : DeletedEvent<ResultPostOwnDto>
    {
    }
}