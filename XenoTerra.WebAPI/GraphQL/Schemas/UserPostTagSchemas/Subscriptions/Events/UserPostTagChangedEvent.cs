using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Subscriptions.Events
{
    public record UserPostTagChangedEvent : ChangedEvent<ResultUserPostTagDto>
    {
    }
}
