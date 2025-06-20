using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events
{
    public record RoleAdminUpdatedEvent : UpdatedEvent<ResultAppRoleAdminDto>
    {
    }
}