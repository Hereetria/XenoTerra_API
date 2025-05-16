using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events
{
    public record StoryChangedSelfEvent : ChangedSelfEvent<ResultStoryDto>
    {
    }
}