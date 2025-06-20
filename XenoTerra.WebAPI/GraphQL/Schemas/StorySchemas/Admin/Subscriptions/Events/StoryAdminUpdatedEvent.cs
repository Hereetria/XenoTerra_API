using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events
{
    public record StoryAdminUpdatedEvent : UpdatedEvent<ResultStoryAdminDto>
    {
    }
}