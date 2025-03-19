using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers
{
    public interface IRoleResolver : IEntityResolver<Role, ResultRoleWithRelationsDto, Guid>
    {
    }
}
