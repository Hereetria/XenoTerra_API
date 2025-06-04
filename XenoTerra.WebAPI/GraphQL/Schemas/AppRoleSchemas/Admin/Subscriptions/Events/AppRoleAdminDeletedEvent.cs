using XenoTerra.DTOLayer.Dtos.AppRoleDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events
{
    public record RoleAdminDeletedEvent : DeletedEvent<ResultAppRoleDto>
    {
    }
}