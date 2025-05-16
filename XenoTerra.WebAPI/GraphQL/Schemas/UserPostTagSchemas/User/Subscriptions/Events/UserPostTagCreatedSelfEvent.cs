using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events
{
    public record UserPostTagCreatedSelfEvent : CreatedSelfEvent<ResultUserPostTagDto>
    {
    }
}
