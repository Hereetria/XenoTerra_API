using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Subscriptions.Events
{
    public record RoleDeletedEvent : DeletedEvent<ResultRoleDto>
    {
    }
}