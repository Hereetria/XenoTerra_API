using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events
{
    public record PostAdminCreatedEvent : CreatedEvent<ResultPostAdminDto>
    {
    }
}