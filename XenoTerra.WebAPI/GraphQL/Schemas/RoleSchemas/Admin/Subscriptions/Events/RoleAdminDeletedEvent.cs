using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events
{
    public record RoleAdminDeletedEvent : DeletedEvent<ResultRoleDto>
    {
    }
}