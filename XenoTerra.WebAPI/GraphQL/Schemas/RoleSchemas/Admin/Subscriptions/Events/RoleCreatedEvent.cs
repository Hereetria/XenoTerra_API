using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events
{
    public record RoleCreatedEvent : CreatedEvent<ResultRoleDto>
    {
    }
}