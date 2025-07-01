using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events
{
    public record ViewStoryAdminChangedEvent : ChangedEvent<ResultViewStoryAdminDto>
    {
    }
}
